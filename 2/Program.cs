/*Problem 2

You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

*/

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new Solution();
        ListNode res = sol.MySolution(new ListNode(2, new ListNode(4, new ListNode(3))), new ListNode(5, new ListNode(6, new ListNode(4)))); 
        Console.WriteLine("Result:");
        // Print the result linked list
        while(res != null){
            Console.WriteLine(res.val);
            res = res.next;
        }
        ListNode bestRes = sol.BestSolution(new ListNode(2, new ListNode(4, new ListNode(3))), new ListNode(5, new ListNode(6, new ListNode(4))));
        Console.WriteLine("Faster Result:");
        // Print the result linked list
        while(bestRes != null){
            Console.WriteLine(bestRes.val);
            bestRes = bestRes.next;
        }
    }
}


 
public class Solution {
    public ListNode MySolution(ListNode l1, ListNode l2) {
        ListNode res = new ListNode(0);
        ListNode resBase = res;
        bool follow = true;
        int carreo = new int();

        while(follow){
                int sum = new int();

                if(l1 != null){
                    sum = sum + l1.val;
                }
                
                if(l2 !=  null){
                    sum = sum + l2.val;
                }
                
                sum = sum + carreo;
                carreo = sum;

                if(sum >= 10){
                    carreo = 1;
                    sum = sum - 10;
                }else{
                    carreo = 0;
                }
                if(l1.next == null && l2.next == null && carreo != 0){
                    res.val = sum;
                    res.next = new ListNode(carreo);
                    follow = false;
                }else if(l1.next == null && l2.next == null){
                    res.val = sum;
                    follow = false;
                }else if(l1.next != null && l2.next != null){
                    res.val = sum;
                    res.next = new ListNode();
                    res = res.next;
                    l1 = l1.next;
                    l2 = l2.next;
                }else if(l1.next != null){
                    res.val = sum;
                    res.next = new ListNode();
                    res = res.next;
                    l1 = l1.next;
                    l2.next = new ListNode();
                    l2 = l2.next;
                }else{
                    res.val = sum;
                    res.next = new ListNode();
                    res = res.next;
                    l1.next = new ListNode();
                    l1 = l1.next;
                    l2 = l2.next;
                }
        }
        
        return resBase;
    }

    public ListNode BestSolution(ListNode l1, ListNode l2) {
        ListNode dummyHead = new ListNode(0);
        ListNode curr = dummyHead;
        int carry = 0;
        while (l1 != null || l2 != null || carry != 0) {
            int x = (l1 != null) ? l1.val : 0;
            int y = (l2 != null) ? l2.val : 0;
            int sum = carry + x + y;
            carry = sum / 10;
            curr.next = new ListNode(sum % 10);
            curr = curr.next;
            if (l1 != null)
                l1 = l1.next;
            if (l2 != null)
                l2 = l2.next;
        }

        return dummyHead.next;
    }
}




public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
      }
  }