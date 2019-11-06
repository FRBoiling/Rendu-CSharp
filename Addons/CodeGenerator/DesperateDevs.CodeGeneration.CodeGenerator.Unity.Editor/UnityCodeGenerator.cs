//using DesperateDevs.DesperateDevs.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using UnityEditor;
using UnityEngine;
using DesperateDevs.Networking;
using DesperateDevs.Serialization;
using DesperateDevs.Utils;

namespace DesperateDevs.CodeGeneration.CodeGenerator.Unity.Editor
{
    public static class UnityCodeGenerator
    {
        public const string DRY_RUN = "DesperateDevs.CodeGeneration.CodeGenerator.Unity.Editor.DryRun";
        private static string _propertiesPath;

        public static Preferences GetPreferences()
        {
            return new Preferences(
                EditorPrefs.GetString("DesperateDevs.CodeGeneration.CodeGenerator.Unity.Editor.PropertiesPath",
                    DesperateDevs.CodeGeneration.CodeGenerator.CodeGenerator.defaultPropertiesPath), Preferences.defaultUserPropertiesPath);
        }

        [MenuItem("Tools/Jenny/Generate #%g", false, 2)]
        public static void Generate()
        {
            Debug.Log((object) "Generating...");
            CodeGenerator codeGenerator = CodeGeneratorUtil.CodeGeneratorFromPreferences(UnityCodeGenerator.GetPreferences());
            float progressOffset = 0.0f;
            codeGenerator.OnProgress += (GeneratorProgress) ((title, info, progress) =>
            {
                if (!EditorUtility.DisplayCancelableProgressBar(title, info, progressOffset + progress / 2f))
                    return;
                codeGenerator.Cancel();
            });
            CodeGenFile[] codeGenFileArray1;
            CodeGenFile[] codeGenFileArray2;
            try
            {
                codeGenFileArray1 = EditorPrefs.GetBool("DesperateDevs.CodeGeneration.CodeGenerator.Unity.Editor.DryRun", true) ? codeGenerator.DryRun() : new CodeGenFile[0];
                progressOffset = 0.5f;
                codeGenFileArray2 = codeGenerator.Generate();
            }
            catch (Exception ex)
            {
                codeGenFileArray1 = new CodeGenFile[0];
                codeGenFileArray2 = new CodeGenFile[0];
                EditorUtility.DisplayDialog("Error", ex.Message, "Ok");
            }

            EditorUtility.ClearProgressBar();
            Debug.Log((object) ("Generated " +
                                (object) ((IEnumerable<CodeGenFile>) codeGenFileArray2).Select<CodeGenFile, string>((Func<CodeGenFile, string>) (file => file.fileName))
                                .Distinct<string>().Count<string>() + " files (" + (object) ((IEnumerable<CodeGenFile>) codeGenFileArray1)
                                .Select<CodeGenFile, string>((Func<CodeGenFile, string>) (file => file.fileContent.ToUnixLineEndings())).Sum<string>((Func<string, int>) (content =>
                                    content.Split(new char[1]
                                    {
                                        '\n'
                                    }, StringSplitOptions.RemoveEmptyEntries).Length)) + " sloc, " + (object) ((IEnumerable<CodeGenFile>) codeGenFileArray2)
                                .Select<CodeGenFile, string>((Func<CodeGenFile, string>) (file => file.fileContent.ToUnixLineEndings()))
                                .Sum<string>((Func<string, int>) (content => content.Split('\n').Length)) + " loc)"));
            AssetDatabase.Refresh();
        }

        [MenuItem("Tools/Jenny/Generate with Server %&g", false, 3)]
        public static void GenerateExternal()
        {
            Debug.Log((object) "Connecting...");
            Preferences preferences = UnityCodeGenerator.GetPreferences();
            UnityCodeGenerator._propertiesPath = preferences.propertiesPath;
            CodeGeneratorConfig andConfigure = preferences.CreateAndConfigure<CodeGeneratorConfig>();
            TcpClientSocket tcpClientSocket = new TcpClientSocket();
            tcpClientSocket.OnConnected += new TcpClientSocket.TcpClientSocketHandler(UnityCodeGenerator.onConnected);
            tcpClientSocket.OnReceived += new TcpSocketReceive(UnityCodeGenerator.onReceive);
            tcpClientSocket.OnDisconnected += new TcpClientSocket.TcpClientSocketHandler(UnityCodeGenerator.onDisconnect);
            tcpClientSocket.Connect(andConfigure.host.ResolveHost(), andConfigure.port);
        }

        private static void onConnected(TcpClientSocket client)
        {
            Debug.Log((object) "Connected");
            Debug.Log((object) "Generating...");
            client.Send(Encoding.UTF8.GetBytes("gen " + UnityCodeGenerator._propertiesPath));
        }

        private static void onReceive(AbstractTcpSocket socket, Socket client, byte[] bytes)
        {
            Debug.Log((object) "Generated");
            socket.Disconnect();
        }

        private static void onDisconnect(AbstractTcpSocket socket)
        {
            Debug.Log((object) "Disconnected");
        }
    }
}