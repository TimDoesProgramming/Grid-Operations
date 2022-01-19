using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class LinkedList
    {
        private Node head;
        public void printAllNodes()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }//end while current is not null
        }//end print All Nodes


        public void AddFirst(Object data)
        {
            Node added = new Node();
            added.data = data;
            added.next = head;

            head = added;
            

        }

        public void AddLast(Object data)
        {
            if(head == null)
            {
                head = new Node();
                head.data = data;
                head.next = null;
            }
            else
            {
                Node toAdd = new Node();
                toAdd.data = data;

                Node current = head;
                while(current.next != null)
                {
                    current = current.next;
                }
                current.next = toAdd;
            }
        }
        public void DeleteLast()
        {
            Node current = head;
                        
            while(true)
            {
                if (current.next.next != null)
                    current = current.next;
                else
                {
                    current = current.next;
                    break;
                }
            }
            //not right
            current = null;

        }
    }
}
