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
    };
}
