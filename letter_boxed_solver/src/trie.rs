use crate::core::St;

pub struct StTrie(usize);

impl StTrie {
    fn new() -> StTrie {
        StTrie(0)
    }

    fn len(&self) -> usize {
        self.0
    }

    fn insert(&mut self, _item: St) {
        self.0 += 1;
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn empty() {
        let trie = StTrie::new();

        assert_eq!(0, trie.len());
    }

    #[test]
    fn one_item_len_1() {
        let mut trie = StTrie::new();

        trie.insert("X".parse::<St>().unwrap());

        assert_eq!(1, trie.len());
    }
}