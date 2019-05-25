#pragma once

#include "Str.h"
#include <unordered_map>

namespace Words
{
    class StrTrie
    {
    public:
        StrTrie();

        size_t size() const;

        void insert(const Str& value);

    private:
        std::unordered_map<Str, bool> nodes_;
    };
}