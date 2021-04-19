using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DNATagger
{
    class FileHandler{
        static StreamReader fileReader;
        static StreamWriter fileWriter;


        public static Boolean openFile(String path)
        {
            if (path == null){
                Console.WriteLine("Error: Tried to open unspecified file");
                return false;
            }
            if (!File.Exists(path)){
                Console.WriteLine("Error: Could not find file: " + path);
                return false;
            }
            try{
                fileReader = File.OpenText(path);
            }
            catch{
                Console.WriteLine("Error: Exception while reading from file");
                return false;
            }
            return true;
        }



        public static void closeFileReader() {
            if (fileReader == null) return;
            fileReader.Close();
            fileReader.Dispose();
            fileReader = null;
        }



        public static void closeFileWriter(){
            if (fileWriter == null) return;
            fileWriter.Flush();
            fileWriter.Close();
            fileWriter.Dispose();
            fileWriter = null;
        }



        public static List<DNASequence> readFasta(String path) {
            List<DNASequence> output = new List<DNASequence>();

            if (openFile(path)){
                StringBuilder fastaBlock = new StringBuilder();
                String line;
                if (fileReader.EndOfStream) Console.WriteLine("Warning: Fasta file is empty");
                else{
                    while (!fileReader.EndOfStream && output.Count < 99){
                        line = fileReader.ReadLine();
                        Console.WriteLine("ping");
                        if (line.Length == 0) continue;
                        if (line.ToCharArray()[0] == '>'){
                            if (fastaBlock.Length > 0){
                                DNASequence seqi = new DNASequence(fastaBlock.ToString());
                                Console.WriteLine("pong");
                                if (!seqi.hasValidSequence()) return output;
                                seqi.notes = "Loaded from: " + path;
                                output.Add(seqi);
                                fastaBlock.Clear();
                            }
                            fastaBlock.Append(line + "\n");
                        }
                        else fastaBlock.Append(line);
                    }
                    DNASequence seq = new DNASequence(fastaBlock.ToString());
                    seq.notes = "Loaded from: " + path;
                    output.Add(seq);
                }
            }
            closeFileReader();
            return output;
        }



        public static bool accessSaveFile(String path){
            try {
                if (path == null) {
                    Console.WriteLine("Alert: Tried to save project without defined filepath!");
                    return false;
                }
                if (File.Exists(path)) File.Delete(path);
                fileWriter = File.CreateText(path);
                return true;
            }
            catch {
                Console.WriteLine("Error while writing to file");
                return false;
            }
        }



        /** <summary>Speichert ein Projekt als dnat Datei ab. Der Dateipfad wird vorher in der path Eigenschaft des Hauptfensters festgelegt.</summary>*/
        public static bool saveProject(WindowMain prj){
            if (!accessSaveFile(prj.savePath)) return false;
            try{
                if (prj.notes != null) fileWriter.WriteLine(prj.notes);
                foreach (DNASequence seq in prj.getSequences()){
                    fileWriter.WriteLine("-Sequence");
                    fileWriter.WriteLine(seq.header);
                    fileWriter.WriteLine(seq.sequence);
                    if (seq.notes != null) fileWriter.WriteLine(seq.notes);
                    foreach (SequenceTag tag in seq.getTags()){
                        fileWriter.WriteLine("-Tag");
                        fileWriter.WriteLine(tag.header);
                        fileWriter.WriteLine(tag.startPos);
                        fileWriter.WriteLine(tag.endPos);
                        fileWriter.WriteLine(tag.BackColor.ToArgb().ToString());
                        if (tag.notes != null) fileWriter.WriteLine(tag.notes);
                    }
                }
                closeFileWriter();
                return true;
            }
            catch{
                Console.WriteLine("Critical Error while saving project! Save while might be corrupted!");
                closeFileWriter();
                return false;
            }
        } 



        /** <summary>Lädt ein Projekt aus einer dnat Datei ein. Die Datei muss vorher in der path Eigenschaft des Hauptfensters festgelegt werden.</summary>*/
        public static bool loadProject(WindowMain prj){
            bool success = false;
            try{
                if (openFile(prj.savePath)){
                    String line;
                    String header;
                    String letters;
                    StringBuilder notes = new StringBuilder();
                    line = fileReader.ReadLine();
                    while(line != "-Sequence" && line != null){ //Zuerst werden alle Projektnotizen am anfang der Datei eingelesen
                        notes.AppendLine(line);
                        line = fileReader.ReadLine();
                    }
                    prj.notes = notes.ToString();
                    notes.Clear();

                    while (!fileReader.EndOfStream){ // Ab hier werden Sequenzen eingelesen
                        header = fileReader.ReadLine();
                        letters = fileReader.ReadLine();
                        if (!DNASequence.isValidSequence(letters)) break;
                        DNASequence seq = new DNASequence(header, letters);
                    
                        line = fileReader.ReadLine();
                        while (line != "-Tag" && line != "-Sequence" && line != null) { //Bevor man auf Tag oder eine neue Sequenz stößt, werden alle folgenden Zeilen als Notes der Sequenz eingelesen
                            notes.AppendLine(line);
                            line = fileReader.ReadLine();
                        }
                        seq.notes = notes.ToString();
                        notes.Clear();
                        prj.addSequence(seq);

                        while (line == "-Tag" && !fileReader.EndOfStream){ //Diese Schleife liest alle tags einer Sequenz ein
                            SequenceTag tag = new SequenceTag(fileReader.ReadLine(), int.Parse(fileReader.ReadLine()), int.Parse(fileReader.ReadLine()), System.Drawing.Color.FromArgb(int.Parse(fileReader.ReadLine())));
                            line = fileReader.ReadLine();
                            while (line != "-Tag" && line != "-Sequence" && line != null) { //Einlesen der Tagnotes, bis neuer Tag neue Sequenz oder Dateiende
                                notes.AppendLine(line);
                                line = fileReader.ReadLine();
                            }
                            tag.notes = notes.ToString();
                            notes.Clear();
                            seq.addTag(tag);
                        }
                    }
                    success = true;
                }
            }
            catch{
                Console.WriteLine("Critical Error while reading project file. It might be corrupted");
            }
            closeFileReader();
            return success;
        }
    }
}
