#pragma once

#include "Str.h"
#include "Vertices.h"
#include <memory>
#include <unordered_map>
#include <unordered_set>

namespace Words
{
    class LetterBoxStrWords
    {
    public:
        struct Word
        {
            Str word;
            Vertices verts;

            Ch last() const
            {
                return word[word.length() - 1];
            }

            bool operator==(const Word& other) const
            {
                return word == other.word;
            }

            bool solvesWith(const Word& w2) const
            {
                Vertices v = verts | w2.verts;
                return v.all();
            }
        };

        LetterBoxStrWords();

        size_t size() const;

        void insert(Str word, Vertices verts);

        template <typename TFound>
        void find(TFound found) const
        {
            for (const auto& values : map_)
            {
                for (const Word& w1 : *(values.second))
                {
                    const auto it = map_.find(w1.last());
                    if (it != map_.cend())
                    {
                        for (const Word& w2 : *(it->second))
                        {
                            if (w1.solvesWith(w2))
                            {
                                found(w1.word, w2.word);
                            }
                        }
                    }
                }
            }
        }

    private:
        typedef std::unordered_set<Word> Set;
        typedef std::unique_ptr<Set> PSet;
        typedef std::unordered_map<Ch, PSet> Map;

        Map map_;
        size_t size_;
    };
}

namespace std
{
    template<> struct hash<Words::LetterBoxStrWords::Word>
    {
        size_t operator()(const Words::LetterBoxStrWords::Word& w) const noexcept
        {
            return w.word.hash_code();
        }
    };
}