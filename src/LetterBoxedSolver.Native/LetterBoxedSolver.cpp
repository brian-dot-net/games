#include "LetterBoxStrSearch.h"
#include "LetterBoxStrWords.h"
#include "Stopwatch.h"
#include <fstream>
#include <cstdarg>

using namespace std;
using namespace Words;

void Log(const char* format, ...)
{
    static Stopwatch watch;

    printf("[%07.3f] ", watch.elapsed());

    va_list args;
    va_start(args, format);
    vprintf(format, args);
    va_end(args);

    printf("\n");
}

int main(int argc, const char** argv)
{
    if (argc != 3)
    {
        printf("Please specify a Letter Boxed puzzle and a word list file.\n");
        return 1;
    }

    LetterBoxStr box(argv[1]);

    Log("Loading trie...");
    ifstream file(argv[2]);
    if (file.fail())
    {
        printf("Could not open file '%s'.\n", argv[2]);
        return 1;
    }

    StrTrie trie(file);

    Log("Loaded %d words.", trie.size());

    LetterBoxStrSearch search(trie, box);
    LetterBoxStrWords words;

    Log("Finding valid words...");
    search.run([&words](Str w, Vertices v) { words.insert(w, v); });
    Log("Found %d valid words.", words.size());

    Log("Finding solutions...");
    words.find([](Str w1, Str w2) { printf("%s-%s\n", w1.str().c_str(), w2.str().c_str()); });

    Log("Done.");

    return 0;
}