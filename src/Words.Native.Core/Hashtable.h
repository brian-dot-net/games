#pragma once

#include <algorithm>
#include <vector>

namespace Words
{
    template<typename TKey, typename TValue, typename TEq = std::equal_to<TKey>, typename THash = std::hash<TKey>>
    class Hashtable
    {
    private:
        struct Entry
        {
            TKey key_;
            TValue value_;
        };

    public:
        Hashtable()
            : eq_(),
            hash_(),
            buckets_(3)
        {
        }

        bool get(const TKey& key, TValue& value) const
        {
            size_t index = find(key);
            const Entry& e = buckets_[index];
            if (!eq_(key, e.key_))
            {
                return false;
            }

            value = e.value_;
            return true;
        }

        bool insert(const TKey& key, TValue&& value)
        {
            size_t index = find(key);
            Entry& e = buckets_[index];
            bool inserted = false;
            if (!eq_(key, e.key_))
            {
                e.key_ = key;
                inserted = true;
            }

            e.value_ = std::move(value);
            return inserted;
        }

    private:
        TEq eq_;
        THash hash_;
        std::vector<Entry> buckets_;

        size_t find(const TKey& key) const
        {
            size_t hashcode = hash_(key);
            return hashcode % buckets_.size();
        }
    };
}