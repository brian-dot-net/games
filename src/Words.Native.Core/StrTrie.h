#pragma once

#include "Str.h"
#include <unordered_map>
#include <istream>

namespace Words
{
    class StrTrie
    {
    public:
        enum NodeKind
        {
            None,
            Prefix,
            Terminal
        };

        StrTrie();

        StrTrie(std::istream& stream);

        size_t size() const;

        void insert(const Str& value);

        NodeKind find(const Str& value) const;

    private:
        typedef std::unordered_map<Str, bool> Map;
        Map nodes_;
        size_t size_;

        StrTrie(const StrTrie&) = delete;
        StrTrie& operator=(const StrTrie&) = delete;
    };
}