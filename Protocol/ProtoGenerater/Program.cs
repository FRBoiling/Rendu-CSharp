using ProtoGenerater.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoGenerater
{
    class Program
    {
        public static string InputPath = null;
        public static string OutputPath = null;
        public static string Filename = null;
        static void Main(string[] args)
        {
   
            //    bool version = false; // --version
            //    bool help = false; // -h, --help

            //1 > --code = all
            //1 > --input_path = D:\GitHub\ServerCluster-master\Protocol\BuildProtocolTest\
            //1 > --output_path = D:\GitHub\ServerCluster-master\Protocol\BuildProtocolTest\
            //1 > --filename = D:\GitHub\ServerCluster-master\Protocol\BuildProtocolTest\Test.Code

            foreach (string arg in args)
            {
                string lhs = arg, rhs = "";
                int index = arg.IndexOf('=');
                if (index > 0)
                {
                    lhs = arg.Substring(0, index);
                    rhs = arg.Substring(index + 1);
                }
                //else if (arg.StartsWith("-o"))
                //{
                //    lhs = "--descriptor_set_out";
                //    rhs = arg.Substring(2);
                //}
                //else if (arg.StartsWith("-I"))
                //{
                //    lhs = "--proto_path";
                //    rhs = arg.Substring(2);
                //}


                //if (lhs.StartsWith("+"))
                //{
                //    if (options == null) options = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                //    options[lhs.Substring(1)] = rhs;
                //    continue;
                //}

                switch (lhs)
                {
                    case "":
                        break;
                    case "--code":
                        break;
                    case "--input_path":
                        InputPath = rhs;
                        break;
                    case "--output_path":
                        OutputPath = rhs;
                        break;
                    case "--filename":
                        if (rhs.ToLower().EndsWith(".code".ToLower()))
                        {
                            Filename = rhs;
                        }
                        else
                        {
                            Console.WriteLine("File type error :{0}  ( mast ends with .code ) ", rhs);
                            return;
                        }
                        break;
                    //case "--version":
                    //    version = true;
                    //    break;
                    //case "--package":
                    //    package = rhs;
                    //    break;
                    //case "-h":
                    //case "--help":
                    //    help = true;
                    //    break;

                    //case "--csharp_out":
                    //    OutPath = rhs;
                    //    //codegen = CSharpCodeGenerator.Default;
                    //    exec = true;
                    //    break;
                    //case "--java_out":
                    //    OutPath = rhs;
                    //    //codegen = CSharpCodeGenerator.Default;
                    //    exec = true;
                    //    break;
                    //case "--cplusplus_out":
                    //    OutPath = rhs;
                    //    //codegen = CSharpCodeGenerator.Default;
                    //    exec = true;
                    //    break;
                    //case "--proto_path":
                    //    importPaths.Add(rhs);
                    //    break;
                    //default:
                    //    if (lhs.StartsWith("-") || !string.IsNullOrWhiteSpace(rhs))
                    //    {
                    //        help = true;
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        inputFiles.Add(lhs);
                    //    }
                    //    break;
                    default:
                        break;
                }
                //生成proto
            }

            CodeFileParser parser = new CodeFileParser();
            parser.ParsingCodeFile(Filename, OutputPath);

            GeneraterManager.Add(1, new CSharpGenerater());
            GeneraterManager.Run(parser);

            Console.ReadLine();
        }
    }
}
