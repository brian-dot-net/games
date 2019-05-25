#include "CppUnitTest.h"
#include "StrTrie.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

namespace Words
{
    TEST_CLASS(StrTrieTest)
    {
    public:
        TEST_METHOD(Empty)
        {
            StrTrie trie;
            
            Assert::AreEqual(size_t(0), trie.size());
        }

        TEST_METHOD(OneItemLength1)
        {
            StrTrie trie;

            trie.insert("X");

            Assert::AreEqual(size_t(1), trie.size());
        }
    };
}
