#pragma once

#include "Str.h"
#include <unordered_map>

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

        size_t size() const;

        void insert(const Str& value);

        NodeKind find(const Str& value) const;

    private:
        std::unordered_map<Str, bool> nodes_;
        size_t size_;
    };
}