use crate::core::St;
use std::collections::HashMap;

#[derive(Debug, PartialEq)]
pub enum NodeKind {
    Prefix,
    Terminal,
}

pub struct StTrie(HashMap<St, bool>);

impl StTrie {
    fn new() -> StTrie {
        let map = HashMap::new();
        StTrie(map)
    }

    fn len(&self) -> usize {
        self.0.len()
    }

    fn insert(&mut self, item: St) {
        self.0.insert(item, true);
    }

    fn find(&self, item: St) -> NodeKind {
        match self.0.get(&item) {
            None => NodeKind::Prefix,
            Some(&t) => if t {
                NodeKind::Terminal
             } else {
                NodeKind::Prefix
             }
        }
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn empty() {
        let trie = init_trie(vec![]);

        assert_eq!(0, trie.len());
    }

    #[test]
    fn one_item_len_1() {
        let trie = init_trie(vec!["X"]);

        assert_eq!(1, trie.len());
    }

    #[test]
    fn two_items_len_2_shared_prefix() {
        let trie = init_trie(vec!["HI", "HA"]);

        assert_eq!(2, trie.len());
        assert_eq!(NodeKind::Prefix, find_trie(&trie, "H"));
        assert_eq!(NodeKind::Terminal, find_trie(&trie, "HA"));
        assert_eq!(NodeKind::Terminal, find_trie(&trie, "HI"));
    }

    #[test]
    fn two_items_len_3_no_shared_prefix() {
        let trie = init_trie(vec!["ABC", "DEF", "GHI"]);

        assert_eq!(3, trie.len());
        assert_eq!(NodeKind::Prefix, find_trie(&trie, "A"));
        assert_eq!(NodeKind::Prefix, find_trie(&trie, "AB"));
        assert_eq!(NodeKind::Terminal, find_trie(&trie, "ABC"));
        assert_eq!(NodeKind::Terminal, find_trie(&trie, "DEF"));
        assert_eq!(NodeKind::Terminal, find_trie(&trie, "GHI"));
    }

    fn init_trie(items: Vec<&str>) -> StTrie {
        let mut trie = StTrie::new();
        for item in items {
            trie.insert(item.parse::<St>().unwrap());
        }

        trie
    }

    fn find_trie(trie: &StTrie, item: &str) -> NodeKind {
        trie.find(item.parse::<St>().unwrap())
    }
}
