using Rd.CodeFileGeneration;
using Rd.Logging;
using Rd.Migration;
using System;
using System.IO;

namespace CodeGenerator
{
    class Program
    {
        private static readonly Logger _logger = fabl.GetLogger(typeof(Program).FullName);
        private static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            int i = 0;
            foreach (var item in args)
            {
                _logger.Debug($"code generator got args {i}:{args[0]}");
                i++;
            }

            if (args.Length < 1)
            {
                _logger.Error($"code generator got error args count :{args.Length} < 1");
                return;
            }
            var key = args[0];
            if (args.Length < 3)
            {
                _logger.Error($"code generator got error args count :{args.Length} < 3");
                return;
            }

            var selectedProjectDir = args[1];
            var outPutPath = args[2];

            var contextsMigration = new RdComponentsMigration();
            contextsMigration.SetLoadName(RdDllLoad.DLLNAME);

            contextsMigration.WorkingDirectory = Path.Combine(selectedProjectDir, contextsMigration.workingDirectory);

            var path = Path.GetDirectoryName(outPutPath);

            _logger.Info($"begin to generator entitas component code by dll in path:{path}");
            _logger.Info($"please wait ...");

            var migrationFiles = contextsMigration.Migrate(outPutPath);

            if (migrationFiles == null || migrationFiles.Length <= 0)
            {
                return;
            }
            MigrationUtils.WriteFiles(migrationFiles);
            _logger.Info("generator success!");

            _logger.Info($"已用时间:{(DateTime.Now - startTime).ToString()}");
            _logger.Info("========== 已完成 ==========");
            Console.ReadKey();
        }
    }
}