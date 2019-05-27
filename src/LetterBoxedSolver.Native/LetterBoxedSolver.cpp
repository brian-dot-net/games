#include "LetterBoxStrSearch.h"
#include "LetterBoxStrWords.h"
#include "Stopwatch.h"
#include <iomanip>
#include <fstream>
#include <sstream>

using namespace std;
using namespace Words;

void Log(const char* line)
{
    static Stopwatch watch;

    cout << "[" << watch.elapsed() << "] " << line << "\r\n";
}

int main(int argc, const char** argv)
{
    if (argc != 3)
    {
        cout << "Please specify a Letter Boxed puzzle and a word list file.\r\n";
        return 1;
    }

    cout << setiosflags(ios::fixed) << setprecision(3);
    LetterBoxStr box(argv[1]);

    Log("Loading trie...");
    ifstream file(argv[2]);
    if (file.fail())
    {
        cout << "Could not open file '" << argv[2] << "'.\r\n";
        return 1;
    }

    StrTrie trie(file);

    stringstream ss;
    ss << "Loaded " << trie.size() << " words.";
    Log(ss.str().c_str());

    LetterBoxStrSearch search(trie, box);
    LetterBoxStrWords words;

    Log("Finding valid words...");
    search.run([&words](Str w, Vertices v) { words.insert(w, v); });
    ss = stringstream();
    ss << "Found " << words.size() << " valid words.";
    Log(ss.str().c_str());
    ss.clear();

    Log("Finding solutions...");
    words.find([](Str w1, Str w2) { cout << w1 << "-" << w2 << "\r\n"; });

    Log("Done.");

    return 0;
}