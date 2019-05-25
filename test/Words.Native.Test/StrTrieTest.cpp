#include "CppUnitTest.h"
#include "StrTrie.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

using namespace Words;

namespace Microsoft
{
    namespace VisualStudio
    {
        namespace CppUnitTestFramework
        {
            template<> static std::wstring ToString<StrTrie::NodeKind>(const StrTrie::NodeKind& t)
            {
                switch (t)
                {
                case StrTrie::Prefix: return L"Prefix";
                case StrTrie::Terminal: return L"Terminal";
                default: return L"None";
                }
            }
        }
    }
}

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

        TEST_METHOD(TwoItemsLength2SharedPrefix)
        {
            StrTrie trie;

            trie.insert("HI");
            trie.insert("HA");

            Assert::AreEqual(size_t(2), trie.size());
            Assert::AreEqual(StrTrie::Prefix, trie.find("H"));
            Assert::AreEqual(StrTrie::Terminal, trie.find("HA"));
            Assert::AreEqual(StrTrie::Terminal, trie.find("HI"));
        }

        TEST_METHOD(ThreeItemsLength3NoSharedPrefix)
        {
            StrTrie trie;

            trie.insert("ABC");
            trie.insert("DEF");
            trie.insert("GHI");

            Assert::AreEqual(size_t(3), trie.size());
            Assert::AreEqual(StrTrie::Prefix, trie.find("A"));
            Assert::AreEqual(StrTrie::Prefix, trie.find("AB"));
            Assert::AreEqual(StrTrie::Terminal, trie.find("ABC"));
            Assert::AreEqual(StrTrie::Terminal, trie.find("DEF"));
            Assert::AreEqual(StrTrie::Terminal, trie.find("GHI"));
        }

        TEST_METHOD(GetNonExistentNode)
        {
            StrTrie trie;
            trie.insert("ABC");

            Assert::AreEqual(StrTrie::None, trie.find("X"));
        }
    };
}
