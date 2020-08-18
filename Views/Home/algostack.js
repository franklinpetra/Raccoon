// This is the class for our Singly Linked Node
class SLNode {
    // The constructor is built to take 1 parameter, being the value of the node we want
    // to create
    constructor(val) {
        // This is the node's actual value
        this.value = val;
        // And this indicates what is next after the current node.
        this.next = null;
    }
}

class SLList {
    constructor() {
        // This is the beginning of the singly linked list
        this.head = null;
    }
    isEmpty(){ return this.head === null; }
    // Write a method that will return a boolean based on whether or not
    // the Singly Linked List contains a node with a given value.

    // EXAMPLE: If the singly linked list is 7 -> 5 -> 9 -> 2 ->
    // and I call myList.contains(9) it should return true.
    // If on the same list I call myList.contains(11) it should return false.
    contains(value) {

    }


    // Write a method that will remove the last node in a SLL and return it.

    // EXAMPLE: If the singly linked list is 11 -> 2 -> 7 -> 6 -> 
    // and I call myList.removeFromBack() the list should now be
    // 11 -> 2 -> 7 -> 
    removeFromback() {
        if (this.isEmpty()){
            console.log("This list is empty.")
            return this;
        }
        else {
            let runner = this.head;
            var current;
            while (runner.next !== null){
                current = runner;
                runner = runner.next;
            }
            current.next = null;
            return runner.val;
        }
    }


    // Write a method that will create a new node, add it to the front of
    // the singly linked list, and reassign the head to the new node.
    addToFront(value) {
        // This one is pretty simple! The case for an empty list vs
        // a non-empty list is exactly the same!
        
        // Create the new node
        let newNode = new SLNode(value);
        let currentHead = this.head;
        // Then set the new node's .next to the current head.
        // IF THE LIST IS EMPTY! newNode.next will be null. Which is what it should be
        // anyway if there's nothing after it.
        // IF THE LIST IS NOT EMPTY! newNode.next will be the current head of the list,
        // which is exactly what we want!
        newNode.next = currentHead;

        // Now, we just set the head of the list to be our new node and call it a day!
        this.head = newNode;
        return this;


    }



    // Write a method that will remove the head node from a singly linked list, 
    // and then reassign the head to the next node. Return the node that was removed
    removeFromFront() {
        // We should first check to see if the list is empty, because if it is,
        // there's nothing to remove!
        if(this.isEmpty()) {
            console.log("There's nothing to remove!");
            return false;
        }

        // Otherwise, let's hold on to the first node
        let removed = this.head;

        // now, we need to move the head to the second node
        this.head = removed.next;

        // And just for funsies, let's clear the previous head's .next so it's a truly standalone node
        removed.next = null;

        // Finally, let's return the removed node!
        return removed;

        // NOTE THAT WE DID NOT CHECK TO SEE IF THE NODE IS THE ONLY NODE IN THE LIST!
        // Similar to the previous algorithm (addToFront), if the original head's .next is null,
        // and you remove from the front, this.head is moved to null, which is fine! Because removing
        // from the front of an SLL with only one node is the same as emptying it!!
    }




    // Write a method that will return a boolean depending on whether or not the singly
    // linked list is empty or not.
    isEmpty() {
        // An empty list in its most simplified form is a list
        // with a head that is null.

        // So what this does, it it grabs the boolean for head == null, and returns that.
        return this.head == null;

        // Alternative:
        if (this.head==null) {
            return true;
        }
        return false;
    }

    // Write a method that is given a value, and adds a new node to the end of a SLL
    // where that new node has that value.
    addToBack(value) {
        // First we need to check if the list is empty
        if(this.isEmpty()){
            // If it is, just set the head to a new node,
            // because adding to the back of an empty list
            // is the same as just setting the head to a node
            this.head = new SLNode(value);
            return this;
        }
        // OTHERWISE
        else {
            // Let's designate a runner to start at the head node
            let runner = this.head;
            // And move it down the list until it reaches the last node
            while(runner.next != null) {
                runner = runner.next;
            }

            // Once the runner is at the end of the list, we set its .next
            // to be a new node
            runner.next = new SLNode(value);
            return this;
        }
    }


    // Write a method that prints the contents of a Singly Linked List.
    printList() {
        // First, let's check if the list is empty
        if(this.isEmpty()) {
            console.log("The list is empty!")
            return;
        }
        // Let's start a runner at the beginning of the singly linked list itself
        var runner = this.head;
        // This string will be added to as we traverse along the SLL
        var string = "";


        // Now we need a way to traverse through the SLL

        // If the runner is not null, we're still looking at a node, so we have things to do!
        while(runner != null) {
            // We want to add the node's value to our string, and a fancy little arrow for looks
            string += runner.value + " -> ";
            // Then, we want to progress the runner to the NEXT node in the SLL
            runner = runner.next;
        }
        
        // Once we've finished moving through the entire list, we want to print the string
        console.log(string);
    }

    printList(){
    if (this.isEmpty()){
        console.log("List is empty.")
        return this
    }
    let runner = this.head;
    let line = `${runner.value}`
    while (runner.next !== null){
        line += ` -> ${runner.next.value}`
        runner = runner.next;
    }
    console.log(line)
    return this        
}
}


var myList = new SLList();

myList.head = new SLNode(5);
myList.head.next = new SLNode(6);
myList.head.next.next = new SLNode(7);

myList.printList();