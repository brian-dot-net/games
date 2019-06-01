#include "Stopwatch.h"
#include "Hashtable.h"
#include <string>

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

    printf("%s : %.3f usec per op\n", name, avgUsecs);
}

void MakeKey(char* k, int v)
{
    for (int i = 0; i < 4; ++i)
    {
        k[i] = 'a' + (v % 26);
        v /= 26;
    }
}

void Insert(int n)
{
    Hashtable<string, int> table;
    char raw[5];
    raw[4] = '\0';
    for (int i = 1; i <= n; ++i)
    {
        MakeKey(raw, i);
        string key(raw);
        table.insert(key, i);
    }
}

int main()
{
    Measure("Insert_10", []() { Insert(10); });
    Measure("Insert_100", []() { Insert(100); });
    Measure("Insert_1000", []() { Insert(1000); });
    Measure("Insert_10000", []() { Insert(10000); });
    Measure("Insert_100000", []() { Insert(100000); });
    return 0;
}