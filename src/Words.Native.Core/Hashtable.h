#pragma once

#include <algorithm>

namespace Words
{
    template<typename TKey, typename TValue, typename TEq = std::equal_to<TKey>, typename THash = std::hash<TKey>>
    class Hashtable
    {
    public:
        Hashtable()
        {
        }

        bool get(const TKey& key, TValue& value) const
        {
            return false;
        }
    };
}