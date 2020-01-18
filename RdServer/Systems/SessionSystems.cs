using Entitas;
using Entitas.Collector;
using Entitas.Context;
using Entitas.Group;
using Rd.Helper;
using Rd.Networking;
using Rd.Networking.IOCP;
using System;
using System.Collections.Generic;
using System.IO;

namespace Server
{
    public class SessionChannelReactiveSystem : ReactiveSystem<SessionEntity>
    {
        Contexts _contexts;
        public SessionChannelReactiveSystem(Contexts contexts) : base(contexts.session)
        {
            _contexts = contexts;
        }

        protected override void Execute(List<SessionEntity> entities)
        {
            foreach (var entity in entities)
            {
                var channel = entity.channel.Channel;
                channel.ErrorCallback += (c, e) =>
                {
                    entity.isOffline = true;
                    Console.WriteLine($"disconnect success! {channel.ToString()}");
                };
                channel.ReadCallback += (memoryStream)=> {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    ushort opcode = BitConverter.ToUInt16(memoryStream.GetBuffer(), Packet.OpcodeIndex);
                    object message;
                    try
                    {
                        object instance = OpcodeTypeComponent.Instance.GetInstance(opcode);
                        //var instance ="";
                        message = channel.Service.Packer.DeserializeFrom(instance, memoryStream);

                        //if (OpcodeHelper.IsNeedDebugLogMessage(opcode))
                        //{
                        //    Log.Msg(message);
                        //}
                    }
                    catch (Exception e)
                    {
                        // 出现任何消息解析异常都要断开Session，防止客户端伪造消息
                        //Log.Error($"opcode: {opcode} {e} ");
                        channel.Error = NetworkErrorCode.PacketParserError;
                        entity.isOffline = true;
                        return;
                    }

                    entity.ReplaceMsgRecv(TimeHelper.Now());
                    if (!(message is IResponse response))
                    {
                        return;
                    }
                    entity.responseDispatcher.Dispatcher.Response(opcode, response);
                
                };
                channel.Start();
            }
        }

        protected override bool Filter(SessionEntity entity)
        {
            return entity.hasChannel;
        }

        protected override ICollector<SessionEntity> GetTrigger(IContext<SessionEntity> context)
        {
            return context.CreateCollector(SessionMatcher.Channel);
        }

    }


    public class SessionSystems : ICleanupSystem
    {
        Contexts _contexts;
        private readonly SessionContext _sessionContext;
        readonly IGroup<SessionEntity> _sessionEntitys;
        readonly List<SessionEntity> _removeSessionEntitys;

        public SessionSystems(Contexts contexts)
        {
            _contexts = contexts;

            _sessionContext = contexts.session;
            _sessionEntitys = _sessionContext.GetGroup(SessionMatcher.Channel);
            _removeSessionEntitys = new List<SessionEntity>();
        }

        public void Cleanup()
        {
            foreach (var entity in _sessionEntitys)
            {
                if (entity.isOffline&&entity.hasChannel)
                {
                    _removeSessionEntitys.Add(entity);

                    //TODO:BOIL 记录channel断开时间，后续根据断开时间做会话的离线缓存机制
                }

                if (entity.flagDestory)
                {
                    //TODO:BOIL 清除离线缓存会话,数据落盘操作等等
                    //移除会话实体
                    entity.Destroy();
                }
            }

            foreach (var entity in _removeSessionEntitys)
            {
                //移除channel
                entity.channel.Channel.Dispose();
                entity.RemoveChannel();
            }
            _removeSessionEntitys.Clear();
        }

    }
}
