public class Trie
{
    //alphabet size
    static readonly int ALPHABET_SIZE = 26;

    //trie node
    class TrieNode
    {
        public TrieNode[] children = new TrieNode[ALPHABET_SIZE];

        //isEndOfWord is true if node represents end of a word
        public bool isEndOfWord;

        public TrieNode()
        {
            isEndOfWord = false;
            for (int i = 0; i < ALPHABET_SIZE; i++)
            {
                children[i] = null;
            }
        }

        static TrieNode root;

        //If not present, insert keys into trie.
        //If the key is prefix of trie node, just marks leaf node
        static void Insert(string key)
        {
            int level;
            int length = key.Length;
            int index;

            TrieNode pCrawl = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';
                if (pCrawl.children[index] == null)
                    pCrawl.children[index] = new TrieNode();

                pCrawl = pCrawl.children[index];
            }

            //mark last node as leaf
            pCrawl.isEndOfWord = true;
        }

        //returns true if key presents in Trie, else false
        static bool Search(string key)
        {
            int level;
            int length = key.Length;
            int index;
            TrieNode pCrawl = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';

                if (pCrawl.children[index] == null)
                    return false;

                pCrawl = pCrawl.children[index];
            }

            return (pCrawl != null && pCrawl.isEndOfWord);
        }
    }
}