using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATagger
{
    class DNASequence
    {
        private String baseSequence;
        private String header;





        public DNASequence(String fasta) {
            String[] fastaParts = fasta.Split('\n');
            if (fastaParts.Length == 2)
            {
                this.header = fastaParts[0];
                this.baseSequence = fastaParts[1];
            }
            else
            {
                this.header = "Unnamed DNA Sequence";
                this.baseSequence = fasta;
            }
        }



        public String getHeader() {
            return this.header;
        }



        public String getSequence() {
            return this.baseSequence;
        }



        public static Boolean isValidDNASequence(String seq) {
            return true;
        }
    }
}
