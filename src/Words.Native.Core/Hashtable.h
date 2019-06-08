#pragma once

#include <algorithm>
#include <vector>
#include <stdexcept>

namespace
{
    static int next_size(int current, float loadFactor)
    {
        static const int sizes[] =
        {
            3, 5, 11, 23, 53, 113, 251, 509, 1019, 2039, 4079, 8179, 16369, 32749, 65521, 131063, 262133,524269,
            1048571, 2097143, 4194287, 8388587, 16777183, 33554393, 67108837, 134217689, 268435399, 536870879,
            1073741789, 2147483647
        };

        for (int next : sizes)
        {
            if (static_cast<int>(loadFactor * next) > current)
            {
                return next;
            }
        }

        throw std::bad_alloc();
    }
}

namespace Words
{
    template<typename TKey, typename TValue, typename TEq = std::equal_to<TKey>, typename THash = std::hash<TKey>>
    class Hashtable
    {
    private:
        typedef std::pair<TKey, TValue> Entry;

    public:
        Hashtable(float loadFactor = 1.0f)
            : eq_(),
            hash_(),
            loadFactor_(loadFactor),
            buckets_(next_size(0, loadFactor)),
            entries_(1)
        {
        }

        bool get(const TKey& key, TValue& value) const
        {
            int index = idx(key);
            int n = static_cast<int>(buckets_.size());
            for (int i = 0; i < n; ++i)
            {
                int b = buckets_[index];
                if (b == 0)
                {
                    break;
                }

                const Entry& e = entries_[b];
                const TKey& k = e.first;
                if (eq_(k, key))
                {
                    value = e.second;
                    return true;
                }

                next_index(index);
            }

            return false;
        }

        bool insert(const TKey& key, const TValue& value, TValue* previous = nullptr)
        {
            int index = idx(key);
            int n = static_cast<int>(buckets_.size());
            for (int i = 0; i < n; ++i)
            {
                int b = buckets_[index];
                if (b == 0)
                {
                    break;
                }

                Entry& e = entries_[b];
                const TKey& k = e.first;
                if (eq_(k, key))
                {
                    if (previous)
                    {
                        *previous = e.second;
                    }

                    e.second = value;
                    return false;
                }

                next_index(index);
            }

            insert_new(index, key, value);
            return true;
        }

    private:
        TEq eq_;
        THash hash_;
        float loadFactor_;
        int size_;
        std::vector<int> buckets_;
        std::vector<Entry> entries_;

        int idx(const TKey& key) const
        {
            size_t hashcode = hash_(key);
            return static_cast<int>(hashcode % buckets_.size());
        }

        void resize()
        {
            std::vector<int> original(next_size(static_cast<int>(buckets_.size()), loadFactor_));
            std::swap(buckets_, original);
            size_ = 0;
            size_t n = entries_.size();
            for (int x = 1; x < n; ++x)
            {
                const Entry& e = entries_[x];
                const TKey& k = e.first;
                put_bucket(-1, k, x);
            }
        }

        void insert_new(int index, const TKey& key, const TValue& value)
        {
            int maxSize = static_cast<int>(loadFactor_ * buckets_.size());
            if (entries_.size() > maxSize)
            {
                resize();
                index = -1;
            }

            put_bucket(index, key, static_cast<int>(entries_.size()));
            entries_.push_back(std::make_pair(key, value));
        }

        void put_bucket(int index, const TKey& key, int x)
        {
            if (index == -1)
            {
                index = idx(key);
            }

            int n = static_cast<int>(buckets_.size());
            for (int i = 0; i < n; ++i)
            {
                int& b = buckets_[index];
                if (b == 0)
                {
                    b = x;
                    return;
                }

                next_index(index);
            }
        }

        void next_index(int& index) const
        {
            ++index;
            int n = static_cast<int>(buckets_.size());
            if (index == n)
            {
                index = 0;
            }
        }
    };
}