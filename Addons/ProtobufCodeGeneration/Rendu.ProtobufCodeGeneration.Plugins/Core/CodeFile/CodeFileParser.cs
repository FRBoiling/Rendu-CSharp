using Rd.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Rendu.ProtobufCodeGeneration.Plugins
{
    public class CodeFileParser
    {
        public CodeFile ParserFile(string fileFullName)
        {
            var index = fileFullName.LastIndexOf("\\", StringComparison.Ordinal);
            if (index < 0)
            {
                throw new Exception($"ParserFile {fileFullName} error : fileFullName format wrong .");
                return null;
            }

            var fileName = fileFullName.Substring(index + 1);

            var lines = FileUtil.ReadLinesFromFile(fileFullName);
            if (lines == null || lines.Count == 0)
            {
                throw new Exception($"ParserFile {fileFullName} error : read file wrong .");
                return null;
            }

            var codeFile = new CodeFile
            {
                Name = fileName,
                FullName = fileFullName
            };

            if (CodeFileFormat(lines, codeFile))
            {
                return codeFile;
            }

            throw new Exception($"ParserFile {fileFullName} error : format file wrong .");
        }
        public CodeFile ParserFile(FileInfo fileInfo)
        {
            var lines = FileUtil.ReadLinesFromFile(fileInfo);
            if (lines == null || lines.Count == 0)
            {
//                throw new Exception($"ParserFile {fileInfo.FullName} error : read file wrong .");
                return null;
            }

            var codeFile = new CodeFile
            {
                Name =  fileInfo.Name,
                FullName = fileInfo.FullName
            };

            if (CodeFileFormat(lines, codeFile))
            {
                return codeFile;
            }
            //throw new Exception($"ParserFile {fileInfo.FullName} error : format file wrong .");
            return null;
        }
        
        private bool CodeFileFormat(IEnumerable<string> lines, CodeFile codeFile)
        {
           var syntaxLine = new StringBuilder();
           var packageLines = new StringBuilder();
//            var optionLine = new StringBuilder();
//            var importLines = new StringBuilder();
            var contextLines = new StringBuilder();

            foreach (var line in lines)
            {
                var trimLine = line.TrimStart();
                if (trimLine.StartsWith(ConstData.SYNTAX_KEY))
                {
                    if (!GetFormatSyntaxLine(trimLine, codeFile, out var syntaxFormatLine))
                    {
                        return false;
                    }

                    syntaxLine.Append(syntaxFormatLine);
                    
                    contextLines.Append(syntaxFormatLine);
                    contextLines.Append(Environment.NewLine);
                }
                else if (trimLine.StartsWith(ConstData.PACKAGE_KEY))
                {
                    if (!GetFormatPackageLine(trimLine, codeFile, out var packageFormatLine))
                    {
                        return false;
                    }

                    packageLines.Append(packageFormatLine);
                    
                    contextLines.Append(packageFormatLine);
                    contextLines.Append(Environment.NewLine);
                }
                else if (trimLine.StartsWith(ConstData.OPTION_KEY))
                {
                    if (!GetFormatOptionLine(trimLine, codeFile, out var optionFormatLine))
                    {
                        return false;
                    }

                    contextLines.Append(optionFormatLine);
                    contextLines.Append(Environment.NewLine);
                }
                else if (trimLine.StartsWith(ConstData.IMPORT_KEY))
                {
                    if (!GetFormatImportLine(trimLine, codeFile, out var importFormatLine))
                    {
                        return false;
                    }

                    contextLines.Append(importFormatLine);
                    contextLines.Append(Environment.NewLine);
                }
                else if (trimLine.StartsWith(ConstData.ANNOTAION_KEY))
                {
                    //The line is annotation 
                }
                else if (trimLine.StartsWith(ConstData.MESSAGE_KEY))
                {
                    if (!GetFormatMessageKeyLine(trimLine, codeFile, out var contextFormatLine))
                    {
                        return false;
                    }

                    contextLines.Append(contextFormatLine);
                    contextLines.Append(Environment.NewLine);
                }
                else if (trimLine.StartsWith(ConstData.ENUM_KEY))
                {
                    if (!GetFormatEnumKeyLine(trimLine, codeFile, out var contextFormatLine))
                    {
                        return false;
                    }

                    contextLines.Append(contextFormatLine);
                    contextLines.Append(Environment.NewLine);
                }
                else
                {
                    if (!GetFormatOtherLine(line, out var otherFormatLine))
                    {
                        return false;
                    }

                    contextLines.Append(otherFormatLine);
                    contextLines.Append(Environment.NewLine);
                }
            }

            if (syntaxLine.Length == 0 || packageLines.Length ==0)
            {
                return false;
            }
            codeFile.SetProtoBuffData(contextLines);
            return true;
        }

        private bool GetFormatOtherLine(string line, out string formatLine)
        {
            formatLine = string.Empty;
            var index = line.IndexOf("//", StringComparison.Ordinal);
            formatLine = index == -1 ? line : line.Substring(0, index);
            return true;
        }

        private bool GetFormatEnumKeyLine(string line, CodeFile codeFile, out string formatLine)
        {
            formatLine = string.Empty;
            var enumKey = ConstData.PACKAGE_KEY;
            var trimLine = StringUtil.TrimStartWord(line, enumKey);
            var enumName = trimLine.Trim();
            if (string.IsNullOrEmpty(enumName))
            {
                throw new Exception($"please check the enum name {line}!");
                //return false;
            }
            if (!codeFile.AddDataStructure(enumName))
            {
                return false;
            }

            formatLine = $"{enumKey} {enumName}";
            return true;
        }

        private bool GetFormatMessageKeyLine(string line, CodeFile codeFile, out string formatLine)
        {
            formatLine = string.Empty;
            var messageKey = ConstData.MESSAGE_KEY;
            var trimLine = StringUtil.TrimStartWord(line, messageKey);
            var formatArr = trimLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            string messageName;
            if (formatArr.Length > 0)
            {
                messageName = formatArr[0];
            }
            else
            {
                return false;
            }

            var messageId = string.Empty;
            if (formatArr.Length > 1)
            {
                messageId = formatArr[1];
            }

            if (!codeFile.AddDataStructure(messageName, messageId))
            {
                return false;
            }

            formatLine = $"{messageKey} {messageName}";
            return true;
        }

        private bool GetFormatOptionLine(string line, CodeFile codeFile, out string formatLine)
        {
            formatLine = string.Empty;
            var optionKey = ConstData.OPTION_KEY;
            var trimLine = StringUtil.TrimStartWord(line, optionKey);
            var option = trimLine.Replace(";", "").Trim();
            if (!codeFile.SetOption(option)) return false;
            formatLine = $"{optionKey} {option};";
            return true;
        }

        private bool GetFormatImportLine(string line, CodeFile codeFile, out string formatLine)
        {
            formatLine = string.Empty;
            var importKey = ConstData.IMPORT_KEY;
            var trimLine = StringUtil.TrimStartWord(line, importKey);
            var importName = trimLine.Replace(";", "").Trim();
            if (!codeFile.AddImport(importName)) return false;
            formatLine = $"{importKey} {importName};";
            return true;
        }
        
        private bool GetFormatPackageLine(string line, CodeFile codeFile, out string formatLine)
        {
            formatLine = string.Empty;
            var packageKey = ConstData.PACKAGE_KEY;
            var trimLine = StringUtil.TrimStartWord(line, packageKey);
            var package = trimLine.Replace(";", "").Trim();
            if (!codeFile.SetPackage(package)) return false;
            formatLine = $"{packageKey} {package};";
            return true;
        }

        private bool GetFormatSyntaxLine(string line, CodeFile codeFile, out string formatLine)
        {
            formatLine = string.Empty;
            var formatArr = line.Split(new[] {"="}, StringSplitOptions.RemoveEmptyEntries);
            if (formatArr.Length > 1)
            {
                var syntaxKey = formatArr[0];
                if (string.CompareOrdinal(syntaxKey, ConstData.SYNTAX_KEY) == -1)
                {
                    throw new Exception($"please check the syntax key,{syntaxKey}!");
                }

                var syntax = formatArr[1].Replace(";", "");
                if (string.CompareOrdinal(syntax, ConstData.SYNTAX) == -1)
                {
                    throw new Exception($"please check the syntax, this {syntax} is wrong!");
                }

                codeFile.SetSyntax(syntax);
                formatLine = $"{syntaxKey}={syntax};";
                return true;
            }

            throw new Exception("please check the syntax line!");
        }
    }
}