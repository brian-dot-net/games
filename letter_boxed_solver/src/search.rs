use crate::{
    core::{Ch, LetterBox, St, Vertices},
    trie::{NodeKind, StTrie},
};
use std::{
    collections::{HashMap, HashSet},
    hash::Hash,
};

pub fn search<F>(trie: &StTrie, b: LetterBox, mut found: F)
where
    F: FnMut(St, Vertices),
{
    for v1 in 0..12 {
        let c = b[v1];
        let verts = Vertices::new(1 << v1);
        search_next(St::empty() + c, v1, verts, &trie, &b, &mut found);
    }
}

fn search_next<F>(str: St, v1: u8, verts: Vertices, trie: &StTrie, b: &LetterBox, found: &mut F)
where
    F: FnMut(St, Vertices),
{
    let kind = trie.find(str);
    if kind == NodeKind::None {
        return;
    }

    if kind == NodeKind::Terminal {
        found(str, verts);
    }

    if str.len() == 12 {
        return;
    }

    let next = b.next(v1);
    for v2 in 0..12 {
        if next[v2] {
            let c = b[v2];
            let next_verts = verts + Vertices::new(1 << v2);
            search_next(str + c, v2, next_verts, &trie, b, found);
        }
    }
}

#[derive(Eq, PartialEq)]
struct Word {
    word: St,
    verts: Vertices,
}

impl Word {
    fn last(&self) -> Ch {
        self.word[self.word.len() - 1]
    }

    fn is_solution_with(&self, other: &Word) -> bool {
        let v = self.verts + other.verts;
        v.is_complete()
    }
}

impl Hash for Word {
    fn hash<H: std::hash::Hasher>(&self, state: &mut H) {
        self.word.hash(state)
    }
}

pub struct LetterBoxWords {
    words: HashMap<Ch, HashSet<Word>>,
    count: usize,
}

impl LetterBoxWords {
    pub fn new() -> LetterBoxWords {
        let words = HashMap::new();
        let count = 0;
        LetterBoxWords { words, count }
    }

    pub fn insert(&mut self, word: St, verts: Vertices) {
        let k = word[0];
        let w = Word { word, verts };
        if let Some(v) = self.words.get_mut(&k) {
            if v.insert(w) {
                self.count += 1;
            }
        } else {
            let mut v = HashSet::new();
            v.insert(w);
            self.words.insert(k, v);
            self.count += 1;
        }
    }

    fn find<F>(&self, mut found: F)
    where
        F: FnMut(St, St),
    {
        for w1 in self.words.values().flat_map(|v| v) {
            if let Some(v) = self.words.get(&w1.last()) {
                for w2 in v {
                    if w1.is_solution_with(&w2) {
                        found(w1.word, w2.word);
                    }
                }
            }
        }
    }

    pub fn len(&self) -> usize {
        self.count
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn empty_finds_nothing() {
        let words = LetterBoxWords::new();

        let expected: Vec<&str> = vec![];
        assert_eq!(expected, solutions(&words));
    }

    #[test]
    fn one_word_finds_nothing() {
        let mut words = LetterBoxWords::new();
        insert_word(&mut words, "ALE", 0b100000010001);

        let expected: Vec<&str> = vec![];
        assert_eq!(expected, solutions(&words));
    }

    #[test]
    fn two_words_invalid_solution_finds_0() {
        let mut words = LetterBoxWords::new();
        insert_word(&mut words, "ALE", 0b100000010001);
        insert_word(&mut words, "ELF", 0b100000110000);

        let expected: Vec<&str> = vec![];
        assert_eq!(expected, solutions(&words));
    }

    #[test]
    fn two_words_valid_solution_finds_1() {
        let mut words = LetterBoxWords::new();
        insert_word(&mut words, "ADBECF", 0b000000111111);
        insert_word(&mut words, "FGJHKIL", 0b111111100000);

        let expected = vec!["ADBECF-FGJHKIL"];
        assert_eq!(expected, solutions(&words));
    }

    #[test]
    fn many_words_finds_all_solutions() {
        let mut words = LetterBoxWords::new();
        insert_word(&mut words, "ADB", 0b000000001011);
        insert_word(&mut words, "ADBECF", 0b000000111111);
        insert_word(&mut words, "BECFHJGKIL", 0b111111111110);
        insert_word(&mut words, "FGJHKIL", 0b111111100000);
        insert_word(&mut words, "FAHKILJG", 0b111111100001);
        insert_word(&mut words, "FAHKILJ", 0b111110100001);

        let expected = vec!["ADB-BECFHJGKIL", "ADBECF-FAHKILJG", "ADBECF-FGJHKIL"];
        assert_eq!(expected, solutions(&words));
    }

    #[test]
    fn counts_words() {
        let mut words = LetterBoxWords::new();

        assert_eq!(0, words.len());

        insert_word(&mut words, "AB", 0);

        assert_eq!(1, words.len());

        insert_word(&mut words, "AB", 0);

        assert_eq!(1, words.len());

        insert_word(&mut words, "ABC", 0);

        assert_eq!(2, words.len());

        insert_word(&mut words, "ABCD", 0);

        assert_eq!(3, words.len());
    }

    #[test]
    fn empty_trie_finds_0() {
        let trie = StTrie::new();
        let expected: Vec<&str> = vec![];

        assert_eq!(expected, words(&trie));
    }

    #[test]
    fn one_value_trie_finds_1() {
        let mut trie = StTrie::new();
        trie.insert("ALE".parse::<St>().unwrap());
        let expected = vec!["ALE:100000010001"];

        assert_eq!(expected, words(&trie));
    }

    #[test]
    fn twelve_value_trie_finds_all_words() {
        let mut trie = StTrie::new();
        trie.insert("ALE".parse::<St>().unwrap());
        trie.insert("BEG".parse::<St>().unwrap());
        trie.insert("CEL".parse::<St>().unwrap());
        trie.insert("DAH".parse::<St>().unwrap());
        trie.insert("ELF".parse::<St>().unwrap());
        trie.insert("FIB".parse::<St>().unwrap());
        trie.insert("GAL".parse::<St>().unwrap());
        trie.insert("HAD".parse::<St>().unwrap());
        trie.insert("ICE".parse::<St>().unwrap());
        trie.insert("JIB".parse::<St>().unwrap());
        trie.insert("KAE".parse::<St>().unwrap());
        trie.insert("LIE".parse::<St>().unwrap());
        let expected = vec![
            "ALE:100000010001",
            "BEG:000001010010",
            "CEL:100000010100",
            "DAH:000010001001",
            "ELF:100000110000",
            "FIB:000100100010",
            "GAL:100001000001",
            "HAD:000010001001",
            "ICE:000100010100",
            "JIB:001100000010",
            "KAE:010000010001",
            "LIE:100100010000",
        ];

        assert_eq!(expected, words(&trie));
    }

    #[test]
    fn search_does_not_return_invalid_moves() {
        let mut trie = StTrie::new();
        trie.insert("ABC".parse::<St>().unwrap());
        trie.insert("DEF".parse::<St>().unwrap());
        trie.insert("GHI".parse::<St>().unwrap());
        trie.insert("JKL".parse::<St>().unwrap());
        trie.insert("MOW".parse::<St>().unwrap());
        trie.insert("ALA".parse::<St>().unwrap());
        let expected = vec!["ALA:100000000001"];

        assert_eq!(expected, words(&trie));
    }

    #[test]
    fn search_does_not_build_too_long_words() {
        let mut trie = StTrie::new();
        trie.insert("LA".parse::<St>().unwrap());
        trie.insert("LALA".parse::<St>().unwrap());
        trie.insert("LALALA".parse::<St>().unwrap());
        trie.insert("LALALALA".parse::<St>().unwrap());
        trie.insert("LALALALALA".parse::<St>().unwrap());
        trie.insert("LALALALALALA".parse::<St>().unwrap());
        let expected = vec![
            "LA:100000000001",
            "LALA:100000000001",
            "LALALA:100000000001",
            "LALALALA:100000000001",
            "LALALALALA:100000000001",
            "LALALALALALA:100000000001",
        ];

        assert_eq!(expected, words(&trie));
    }

    fn insert_word(words: &mut LetterBoxWords, word: &str, bits: u16) {
        words.insert(word.parse::<St>().unwrap(), Vertices::new(bits));
    }

    fn solutions(words: &LetterBoxWords) -> Vec<String> {
        let mut found = vec![];

        words.find(|w1, w2| found.push(format!("{}-{}", w1, w2)));

        found.sort();
        found
    }

    fn words(trie: &StTrie) -> Vec<String> {
        let mut found = vec![];
        let b = LetterBox::new("ABCDEFGHIJKL".parse::<St>().unwrap());

        search(&trie, b, |w, v| found.push(format!("{}:{}", w, v)));

        found
    }
}
