#include "LetterBoxStrWords.h"

using namespace std;
using namespace Words;

LetterBoxStrWords::LetterBoxStrWords()
    : map_()
{
}

size_t LetterBoxStrWords::size() const
{
    return size_;
}


void LetterBoxStrWords::insert(Str word, Vertices verts)
{
    Ch key = word[0];
    Word w = { word, verts };
    Map::iterator it = map_.find(key);
    if (it != map_.end())
    {
        auto pair = it->second->insert(w);
        if (pair.second)
        {
            ++size_;
        }

        return;
    }

    unique_ptr<Set> words = make_unique<Set>();
    words->insert(w);
    map_.insert(make_pair(key, move(words)));
    ++size_;
}