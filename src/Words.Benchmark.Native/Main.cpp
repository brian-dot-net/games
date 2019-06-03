#include "Stopwatch.h"
#include "Hashtable.h"
#include <string>
#include <sstream>

using namespace std;
using namespace Words;

template<typename TFunc>
float MeasureN(TFunc func, int n)
{
    Stopwatch watch;
    for (int i = 0; i < n; ++i)
    {
        func();
    }

    return watch.elapsed();
}

template<typename TFunc>
int TrialMeasure(TFunc func)
{
    int count = 2;
    float elapsed;
    do
    {
        count *= 2;
        elapsed = MeasureN(func, count);
    } while (elapsed < 0.01f);

    return count;
}

template<typename TFunc>
void Measure(const char* name, TFunc func)
{
    int n = TrialMeasure(func);
    double totalUsecs = 0.0;
    int ops = 0;
    for (int i = 0; i < 10; ++i)
    {
        double secs = static_cast<double>(MeasureN(func, n));
        totalUsecs += secs * 1000000;
        ops += n;
    }

    double avgUsecs = totalUsecs / ops;

    printf("%s : % 10.3f usec per op\n", name, avgUsecs);
}

void MakeKey(char* k, int v)
{
    for (int i = 0; i < 4; ++i)
    {
        k[i] = 'a' + (v % 26);
        v /= 26;
    }
}

void Fill(Hashtable<string, int>& table, int n)
{
    char raw[5];
    raw[4] = '\0';
    for (int i = 1; i <= n; ++i)
    {
        MakeKey(raw, i);
        string key(raw);
        table.insert(key, i);
    }
}

void Insert(int n, float loadFactor)
{
    Hashtable<string, int> table(loadFactor);
    Fill(table, n);
}

int FindPresent(const Hashtable<string, int>& table, int n)
{
    char raw[5];
    raw[4] = '\0';
    int sum = 0;
    for (int i = 1; i <= n; ++i)
    {
        MakeKey(raw, i);
        string key(raw);
        int v;
        if (table.get(key, v))
        {
            sum += v;
        }
    }

    return 0;
}

int FindMissing(const Hashtable<string, int>& table, int n)
{
    char raw[6];
    raw[4] = '_';
    raw[5] = '\0';
    int sum = 0;
    for (int i = 1; i <= n; ++i)
    {
        MakeKey(raw, i);
        string key(raw);
        int v;
        if (table.get(key, v))
        {
            sum += v;
        }
    }

    return 0;
}

int main()
{
    for (int i = 1; i <= 4; ++i)
    {
        float f = i / 4.0f;
        int n = 1;
        for (int j = 1; j <= 5; ++j)
        {
            n *= 10;
            stringstream s;
            s << "     Insert_1e" << j << "_" << i << "/4";
            Measure(s.str().c_str(), [n, f]() { Insert(n, f); });

            Hashtable<string, int> table(f);
            s = stringstream();
            s << "FindPresent_1e" << j << "_" << i << "/4";
            Measure(s.str().c_str(), [&table, n]() { FindPresent(table, n); });

            s = stringstream();
            s << "FindMissing_1e" << j << "_" << i << "/4";
            Measure(s.str().c_str(), [&table, n]() { FindMissing(table, n); });
        }
    }

    return 0;
}