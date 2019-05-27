#include "CppUnitTest.h"
#include "LetterBoxStrSearch.h"
#include <vector>
#include <bitset>
#include <string>

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

namespace Words
{
    TEST_CLASS(LetterBoxStrSearchTest)
    {
    public:
        TEST_METHOD(EmptyTrieFindsNothing)
        {
            StrTrie trie;
            LetterBoxStrSearch search(Init(trie));

            FindWords(search, {});
        }

    private:
        LetterBoxStrSearch Init(const StrTrie& trie)
        {
            return LetterBoxStrSearch(trie, LetterBoxStr("ABCDEFGHIJKL"));
        }

        void FindWords(const LetterBoxStrSearch& search, initializer_list<string> expected)
        {
            vector<string> found;
            vector<string> expectedFound(expected);

            search.run([&found](Str w, bitset<12> v)
                {
                    stringstream ss;
                    ss << w << ":" << v;
                    found.push_back(ss.str());
                });

            Assert::AreEqual(expected.size(), found.size());
            for (int i = 0; i < expected.size(); ++i)
            {
                Assert::AreEqual(expectedFound[i].c_str(), found[i].c_str());
            }
        }
    };
}
