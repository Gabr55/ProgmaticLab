from collections import deque

tree = {
 "a": {
   "a1": {
     "a2": {
       "c": {
         "c1": {
           "c2": ""
         }
       }
     }
   }
 },
 "b": {
   "c": {
     "c1": {
       "c2": ""
     }
   }
 }
}



def getCommonParent(tree):
   search_queue = deque([("tree", tree)]) 
   checked = set()

   while search_queue:
       parent_key, node = search_queue.popleft()
       for node_key, node_value in node.items():
            if node_key not in checked:
               checked.add(node_key)
               search_queue.append((node_key, node_value))
            else:
               return node_key
   return None

print(getCommonParent(tree))