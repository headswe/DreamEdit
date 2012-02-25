using System;
using System.IO;
using System.Collections.Generic;

/** Usage:
DMParser p = new DMParser();
FileStream f = new FileStream("myfile.dm", FileMode.Open);
p.parseFile(f, "myfile.dm");

foreach(DMToken token in p.tokens) {
    Console.WriteLine(p.pathToString() + " at " + p.lineno);
}
*/
namespace Parser
{

    /* Represents a line parsed from the source. **/
    public class DMToken
    {
        public String filename; // name this token occured in
        public int lineno;      // linenumber of this token
        public int indentation; // indentation of this token
        public List<String> relative_path; // path of the token itself
        public List<String> path; // path of the token when taking its parents into account

        public DMToken(String filename, int lineno, int indentation, List<String> raw_path, List<String> path)
        {
            this.filename = filename;
            this.lineno = lineno;
            this.relative_path = raw_path;
            this.path = path;
            this.indentation = indentation;
        }

        public String pathToString()
        {
            String p = "";
            foreach (String s in path)
            {
                p += s + "/";
            }
            return p;
        }
    }

    /** Class that parses all in the filestreams given to it. **/
    public class DMParser
    {
        public List<DMToken> tokens = new List<DMToken>(); // contains ALL built tokens

        /** Use this function to pass in all the files to the parser. Only create one parser per DME. **/
        public void parseFile(FileStream file, String filename)
        {
            this.filename = filename;
            this.lineno = 0;
            this.linepos = 0;

            reader = new StreamReader(file);

            while (true)
            {
                line = reader.ReadLine();
                if (line == null) return;

                lineno++; linepos = 0;

                int indentation = getIndentation();

                if (funcIndent != 0)
                {
                    if (indentation < funcIndent && !tryEmptyLine())
                    {
                        funcIndent = 0;
                    }
                }

                // only parse the line if we're not in a function
                if (funcIndent == 0)
                {
                    List<String> path = parsePath();

                    if (path != null)
                    {
                        if (indentation == current_path.Count)
                        {
                            current_path.Add(path);
                        }
                        else if (indentation == current_path.Count - 1)
                        {
                            current_path[indentation] = path;
                        }
                        else if (indentation < current_path.Count - 1)
                        {
                            while (indentation < current_path.Count - 1)
                            {
                                current_path.RemoveAt(current_path.Count - 1);
                            }
                            current_path[indentation] = path;
                        }

                        List<String> total_path = new List<String>();
                        foreach (List<String> sub in current_path) foreach (String s in sub) total_path.Add(s);
                        DMToken token = new DMToken(filename, lineno, indentation, path, total_path);
                        tokens.Add(token);
                    }

                    while (linepos < line.Length && (line[linepos] == ' ' || line[linepos] == '\t'))
                    {
                        linepos++;
                    }

                    if (linepos < line.Length)
                    {
                        if (line[linepos] == '(')
                        {
                            funcIndent = indentation + 1;
                        }
                    }
                }

                bool instring = false;

                // parse any multi-line comments
                while (linepos < line.Length)
                {
                    char c = line[linepos];

                    if (consume("/*") && !instring)
                    {
                        consumeMultiComment();
                        break;
                    }
                    else if (consume("{\"") && !instring)
                    {
                        consumeMultiString();
                        break;
                    }
                    else if (c == '"')
                    {
                        instring = !instring;
                    }

                    linepos++;
                }
            }
        }

        private String getNext(int amount)
        {
            if (linepos + amount > line.Length) return null;

            return line.Substring(linepos, amount);
        }

        private bool consume(String s)
        {
            if (getNext(s.Length) == s)
            {
                linepos += s.Length;
                return true;
            }
            else return false;
        }

        private List<String> parsePath()
        {
            List<String> path = new List<String>();
            String this_word = "";

            int startpos = linepos;

            if (linepos == line.Length) return null;

            // skip the first /
            if (line[linepos] == '/') linepos++;

            while (linepos < line.Length)
            {
                char c = line[linepos];
                if (c == '/')
                {
                    if (this_word == "")
                    {
                        linepos = startpos;
                        return null;
                    }
                    path.Add(this_word);
                    this_word = "";
                }
                else if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c == '_'))
                {
                    this_word += c;
                }
                else
                {
                    break;
                }
                linepos++;
            }

            if (this_word != "") path.Add(this_word);

            if (path.Count == 0)
            {
                linepos = startpos;
                return null;
            }
            return path;
        }

        private int getIndentation()
        {
            int rval = 0;
            while (linepos < line.Length)
            {
                char c = line[linepos];
                if (c == '\t' || c == ' ')
                {
                    rval++;
                    linepos++;
                }
                else break;
            }
            return rval;
        }

        private bool tryEmptyLine()
        {
            bool slashFound = false;
            while (linepos < line.Length)
            {
                char c = line[linepos];

                if (slashFound)
                {
                    if (c == '/') return true; // comment found, line empty otherwise
                    else if (c == '*')
                    {
                        consumeMultiComment();
                        return true;
                    }
                    else
                    {
                        return false; // a single slash means the line is not empty
                    }
                }

                if (c == '/')
                {
                    slashFound = true;
                }
                else if (c == ' ' || c == '\t')
                {
                }
                else
                {
                    return false;
                }

                linepos++;
            }
            return true;
        }

        private void consumeMultiComment()
        {
            while (line != null)
            {
                while (reader.EndOfStream == false && linepos >= line.Length)
                {
                    line = reader.ReadLine();
                    lineno++; linepos = 0;
                }
                if (line == null || reader.EndOfStream == true) return;

                if (consume("*/"))
                {
                    return;
                }
                else
                {
                    linepos++;
                }
            }
        }

        private void consumeMultiString()
        {
            while (line != null)
            {
                while (reader.EndOfStream == false && linepos >= line.Length)
                {
                    line = reader.ReadLine();
                    lineno++; linepos = 0;
                }
                if (line == null || reader.EndOfStream == true) return;

                if (consume("\"}"))
                {
                    return;
                }
                else
                {
                    linepos++;
                }
            }
        }


        private StreamReader reader;
        private String filename;
        private String line;
        private int lineno;
        private int linepos;
        private List<List<String>> current_path = new List<List<String>>();
        private int funcIndent = 0;


    }
}
