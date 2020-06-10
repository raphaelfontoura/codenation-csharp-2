using System;
using Xunit;

namespace Codenation.Challenge
{
    public class CesarCypherTest
    {
        CesarCypher cypher = new CesarCypher();

        [Fact]
        public void Should_Not_Accept_Null_When_Crypt()
        {            
            Assert.Throws<ArgumentNullException>(() => cypher.Crypt(null));
        }

        [Fact]
        public void Should_Not_Accept_EspecialChar_When_Crypt()
        {            
            // var cypher = new CesarCypher();
            Assert.Throws<ArgumentOutOfRangeException>(() => cypher.Crypt("áçãó"));
        }

        [Fact]
        public void Should_Keep_EmptyMessage_Out_When_Crypt()
        {
            // var cypher = new CesarCypher();
            Assert.Equal("", cypher.Crypt(""));
        }

        [Fact]
        public void Should_Change_Char_Out_When_Crypt()
        {
            // var cypher = new CesarCypher();
            Assert.Equal("defg", cypher.Crypt("abcd"));
        }

        [Fact]
        public void Should_Keep_Numbers_Out_When_Crypt()
        {
            // var cypher = new CesarCypher();
            Assert.Equal("d1e2f3g4h5i6j7k8l9m0", cypher.Crypt("a1b2c3d4e5f6g7h8i9j0"));
        }

        [Fact]
        public void Should_Keep_Spaces_Out_When_Crypt()
        {
            // var cypher = new CesarCypher();
            Assert.Equal("de fg hi", cypher.Crypt("ab cd ef"));
        }

        [Fact]
        public void Should_Keep_aToz_Out_When_Crypt()
        {
            // var cypher = new CesarCypher();
            Assert.Equal("defgzabc", cypher.Crypt("abcdwxyz"));
        }

        [Fact]
        public void Should_Keep_Frase_Challenge_When_Crypt()
        {
            // var cypher = new CesarCypher();
            Assert.Equal("wkh txlfn eurzq ira mxpsv ryhu wkh odcb grj", cypher.Crypt("the quick brown fox jumps over the lazy dog"));
        }

        [Fact]
        public void Should_Keep_Frase_Challenge_When_DeCrypt()
        {
            // var cypher = new CesarCypher();
            Assert.Equal("the quick brown fox jumps over the lazy dog", cypher.Decrypt("wkh txlfn eurzq ira mxpsv ryhu wkh odcb grj"));
        }

        [Fact]
        public void Should_Keep_aToz_Out_When_DeCrypt()
        {
            // var cypher = new CesarCypher();
            Assert.Equal("abcdwxyz", cypher.Decrypt("defgzabc"));
        }

    }
}
