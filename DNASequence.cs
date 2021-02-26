using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATagger
{
    class DNASequence
    {
        private char[] sense;
        private char[] antisense;
        private String header;





        public DNASequence(String fasta) {
            String[] fastaParts = fasta.Split('\n');
            if (fastaParts.Length == 2)
            {
                this.header = fastaParts[0];
                this.sense = fastaParts[1].ToCharArray();
            }
            else
            {
                this.header = "Unnamed DNA Sequence";
                this.sense = fasta.ToCharArray();
            }
        }



        public String getHeader() {
            return this.header;
        }



        public char getBase(int pos) {
            if (pos <= 0 || pos > this.sense.Length) {
                Console.WriteLine("Error: Baseindex out of Bounds");
                return '?';
            }
            return this.sense[pos - 1];
        }



        public int getLength() {
            return this.sense.Length;
        }



        public static Boolean isValidDNASequence(String seq) {
            return true;
        }
    }
}
