#pragma once

#include <algorithm>
#include <vector>
#include <stdexcept>

namespace
{
    static int nextSize(int current, float loadFactor)
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
        struct Entry
        {
            Entry()
                : key_(),
                value_(),
                occupied_(false)
            {
            }

            TKey key_;
            TValue value_;
            bool occupied_;
        };

    public:
        Hashtable(float loadFactor = 1.0f)
            : eq_(),
            hash_(),
            buckets_(nextSize(0, loadFactor)),
            loadFactor_(loadFactor),
            size_(0)
        {
        }

        bool get(const TKey& key, TValue& value) const
        {
            const Entry* e = find(key);
            if (!e)
            {
                return false;
            }

            if (e->occupied_)
            {
                value = e->value_;
                return true;
            }

            return false;
        }

        bool insert(const TKey& key, const TValue& value, TValue* previous = nullptr)
        {
            bool inserted = false;
            Entry& e = find(key);
            if (!e.occupied_)
            {
                e.occupied_ = true;
                e.key_ = key;
                inserted = true;
                ++size_;
            }

            if (previous)
            {
                *previous = e.value_;
            }

            e.value_ = value;
            return inserted;
        }

    private:
        TEq eq_;
        THash hash_;
        std::vector<Entry> buckets_;
        float loadFactor_;
        int size_;

        size_t idx(const TKey& key) const
        {
            size_t hashcode = hash_(key);
            return hashcode % buckets_.size();
        }

        const Entry* find(const TKey& key) const
        {
            size_t index = idx(key);
            for (int i = 0; i < size_; ++i)
            {
                const Entry& e = buckets_[index];
                if (!e.occupied_ || eq_(e.key_, key))
                {
                    return &e;
                }

                ++index;
                if (index == buckets_.size())
                {
                    index = 0;
                }
            }

            return nullptr;
        }

        Entry& find(const TKey& key)
        {
            size_t index = idx(key);
            while (true)
            {
                Entry& e = buckets_[index];
                if (!e.occupied_ || eq_(e.key_, key))
                {
                    return e;
                }

                int maxSize = static_cast<int>(loadFactor_ * buckets_.size());
                if (size_ >= maxSize)
                {
                    resize();
                    index = idx(key);
                }
                else
                {
                    ++index;
                    if (index == buckets_.size())
                    {
                        index = 0;
                    }
                }
            }
        }

        void resize()
        {
            std::vector<Entry> original(nextSize(static_cast<int>(buckets_.size()), loadFactor_));
            std::swap(buckets_, original);
            size_ = 0;
            for (const Entry& e : original)
            {
                insert(e.key_, e.value_);
            }
        }
    };
}