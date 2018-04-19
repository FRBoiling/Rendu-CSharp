namespace Protocol.TEST.test
{
     public class Generater
     {
          public static void GenerateId()
          {
               Protocol.MsgId.Id<MSG_TEST_Test1>.Value= 0xff00001;
               Protocol.MsgId.Id<MSG_TEST_Test2>.Value= 0xff00002;
               Protocol.MsgId.Id<MSG_TEST_Test3>.Value= 0xff00003;
          }
     }
}
