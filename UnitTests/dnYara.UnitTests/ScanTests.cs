using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dnYara.UnitTests
{
    public class ScanTests
    {
        [Fact]
        public void CheckStringMatchTest()
        {
            // Initialize yara context
            using (YaraContext ctx = new YaraContext())
            {
                // Compile yara rules
                CompiledRules rules = null;

                using (var compiler = new Compiler())
                {
                    compiler.AddRuleString("rule foo: bar {strings: $a = \"lmn\" condition: $a}");

                    rules = compiler.Compile();
                }

                if (rules != null)
                {
                    // Initialize the scanner
                    var scanner = new Scanner();

                    List<ScanResult> scanResult =  scanner.ScanString("abcdefgjiklmnoprstuvwxyz", rules);

                    Assert.True(scanResult.Count > 0);
                }
            }
        }

        [Fact]
        public void CheckStringNotMatchTest()
        {
            // Initialize yara context
            using (YaraContext ctx = new YaraContext())
            {
                // Compile yara rules
                CompiledRules rules = null;

                using (var compiler = new Compiler())
                {
                    compiler.AddRuleString("rule foo: bar {strings: $a = \"nml\" condition: $a}");

                    rules = compiler.Compile();
                }

                if (rules != null)
                {
                    // Initialize the scanner
                    var scanner = new Scanner();
                    List<ScanResult> scanResult = scanner.ScanString("abcdefgjiklmnoprstuvwxyz", rules);

                    Assert.True(scanResult.Count == 0);
                }
            }
        }

        [Fact]
        public void CheckMemoryMatchTest()
        {
            // Initialize yara context
            using (YaraContext ctx = new YaraContext())
            {
                // Compile yara rules
                CompiledRules rules = null;

                using (var compiler = new Compiler())
                {
                    compiler.AddRuleString("rule foo: bar {strings: $a = \"lmn\" condition: $a}");

                    rules = compiler.Compile();
                }

                if (rules != null)
                {
                    // Initialize the scanner
                    var scanner = new Scanner();

                    Encoding encoding = Encoding.ASCII;

                    byte[] buffer = encoding.GetBytes("abcdefgjiklmnoprstuvwxyz");

                    List<ScanResult> scanResult = scanner.ScanMemory(ref buffer, rules);

                    Assert.True(scanResult.Count > 0);
                }
            }
        }

        [Fact]
        public void CheckMemoryNotMatchTest()
        {
            // Initialize yara context
            using (YaraContext ctx = new YaraContext())
            {
                // Compile yara rules
                CompiledRules rules = null;

                using (var compiler = new Compiler())
                {
                    compiler.AddRuleString("rule foo: bar {strings: $a = \"nml\" condition: $a}");

                    rules = compiler.Compile();
                }

                if (rules != null)
                {
                    // Initialize the scanner
                    var scanner = new Scanner();

                    Encoding encoding = Encoding.ASCII;

                    byte[] buffer = encoding.GetBytes("abcdefgjiklmnoprstuvwxyz");

                    List<ScanResult> scanResult = scanner.ScanMemory(ref buffer, rules);

                    Assert.True(scanResult.Count == 0);
                }
            }
        }
    }
}