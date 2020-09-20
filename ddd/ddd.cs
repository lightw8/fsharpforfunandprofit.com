// ======================================================
// This page contains C# code snippets adapted from the talk
// "Domain-driven design with the F# type system"
// ======================================================

// To execute code in Visual Studio Code Insiders Preview, 
//  (a) install the .NET Interactive plugin
//  (b) Highlight code, right click and choose "Send to Interactive"

// Try it! highlight from here ===>
using System;

var three = 1 + 2;
Func<double, double> square = x => x * x;
Console.WriteLine($"Three is {three}");
Console.WriteLine($"Three is {sqaure(three)}");
// <==== highlight to here and Run

// ======================================================
// demonstration of Record types in C#
// ======================================================

// highlight from here ===>
namespace FirstSlide
{
    record Contact(

      string FirstName,
      string MiddleInitial,
      string LastName,

      string EmailAddress,
      string IsEmailVerified  // true if ownership of email address is confirmed

      );
}
    // The issues with this design are:
    // * Which values are optional?
    // * Whare the constraints?
    // * What groups of properties are linked?
    // * Is there any domain logic that we need to be aware of?
// <==== highlight to here and Run

// ======================================================
// demonstration of Record types in C#
// ======================================================

// highlight from here ===>
// define the type
namespace RecordTypeExample
{
    record PersonalName(string FirstName, string LastName);
}
// <==== highlight to here and Run


// highlight from here ===>
// test the code 
namespace TestRecordTypeExample
{
    using RecordTypeExample;
        
    var alice = new Person(FirstName: "Alice", LastName: "Adams");
    var aliceClone = new Person(FirstName: "Alice", LastName: "Adams");
    Console.WriteLine($"Alice's name is {alice}");
    Console.WriteLine($"AliceClone's name is {aliceClone}");
    Console.WriteLine($"Are Alice and clone equal? {alice == aliceClone}");
}
// <==== highlight to here and Run 

// NOTE you may need to scroll up in the outpt window to see the print statements



// ======================================================
// demonstration of Entity types in C#
// ======================================================

// highlight from here ===>
// define the type
namespace EntityTypeExample {

    // immutable object type compared by value
    record PersonalName(string FirstName, string LastName);

    // immutable object type compared by custom member logic
    record Person(int Id, PersonalName Name)
    {
        public override bool Equals(object other) => other switch
            { 
                Person p => Id == p.Id,
                _        => false
            };
        
        public override int this.GetHashCode() => this.Id.GetHashCode();
    }

    // similar to Person class above except without "superset" features of record types ("with" expression, etc)
    class Person2
    {
        public int Id { get; init; }
        public PersonalName Name { get; init; }

        public override bool Equals(object other) => other switch
        {
            Person p => Id == p.Id,
            _ => false
        };

        public override int this.GetHashCode() => this.Id.GetHashCode();
    }
}
// <==== highlight to here and Run


// highlight from here ===>
// test the code 
namespace TestEntityTypeExample {

    using EntityTypeExample;
    
    var alice = new Person(Id: 1, Name: new PersonalName(FirstName: "Alice", LastName="Adams"));
    var bilbo = new Person(Id: 1, Name: new PersonalName(FirstName: "Bilbo", LastName = "Baggins"));
    Console.WriteLine($"Alice is {alice}");
    Console.WriteLine($"Bilbo is {bilbo}");
    Console.WriteLine($"Are Alice and Bilbo equal? {alice == bilbo}");
    Console.WriteLine($"Are Alice.Name and Bilbo.Name equal? {alice.Name == bilbo.Name}");
}
// <==== highlight to here and Run


// ======================================================
// Record versioning in C#
// ======================================================

// highlight from here ===>
// define the type
namespace RecordVersioningExample { 

    using System;
    
    // immutable object type compared by value
    record PersonalName(string FirstName, string LastName);

    // immutable object type compared by custom member logic
    record Person(int Id, Guid Version, PersonalName Name)
    {
        public override bool Equals(object other) => other switch
            { 
                Person p => Id == p.Id && Version == p.Version,
                _        => false
            };

        public override int GetHashCode() => this.Id.GetHashCode();
    }

    // same as Person class above except without "superset" features of record types ("with" expression, etc)
    class Person2
    {
        public int Id { get; init; }
        public Guid Version { get; init; }
        public PersonalName Name { get; init; }

        public override bool Equals(object other) => other switch
            {
                Person p => Id == p.Id && Version == p.Version,
                _ => false
            };

        public override int this.GetHashCode() => this.Id.GetHashCode();
    }
}
// <==== highlight to here and Run


// highlight from here ===>
// test the code 
namespace TestRecordVersioningExample { 

    using RecordVersioningExample;
    using System;

    var alice = new Person(Id: 1, Version: Guid.NewGuid(), 
        Name: new(FirstName: "Alice", LastName: "Adams"));

    var aliceV2 = alice with
        { 
            Version: Guid.NewGuid(),
            Name: new PersonalName(FirstName: "Al", LastName:"Adamson")
        };
    
    Console.WriteLine($"Alice is {alice}");
    Console.WriteLine($"AliceV2 is {aliceV2}");
    Console.WriteLine($"Are Alice and AliceV2 equal? {alice == aliceV2}"); // no compiler error in C#
    Console.WriteLine($"Are Alice and AliceV2 same id? {alice.Id == aliceV2.Id}");
    Console.WriteLine($"Are Alice and AliceV2 same version? {alice.Version == aliceV2.Version}");
}
// <==== highlight to here and Run

// ======================================================
// Record object definition in C# with mutability
// ======================================================

// highlight from here ===>
// define the type
namespace RecordMutabilityExample {

    // immutable object type compared by value
    record PersonalName(string FirstName, string LastName);

    // object type compared by value with one mutable property
    record Person(int Id){ public PersonalName Name { get; set; } } 
}
// <==== highlight to here and Run



// highlight from here ===>
// test the code 
namespace TestEntityMutabilityExample {

    using EntityMutabilityExample;
    
    var alice = new Person(Id: 1){ Name = new PersonalName(FirstName: "Alice", LastName: "Adams") }
    Console.WriteLine($"Alice before change is {alice}");
                
    alice.Name = new PersonalName(FirstName: "Al", LastName: "Adamson");
    Console.WriteLine($"Alice after change is {alice}");
}
// <==== highlight to here and Run

// ======================================================
// Review of code so far
// ======================================================

// highlight from here ===>
namespace ValueAndEntityReview { 

    record PersonalName(         // an immuntable object compared by value
        FirstName string,
        LastName string);
         
    class Person {                // an object with immutable properties compared by reference
        public int Id { get; init; }
        public PersonalName Name { get; init; }
    }
}

// <==== highlight to here and Run


// ======================================================
// Ubiquitous language
// ======================================================

// highlight from here ===>
namespace CardGameBoundedContext = 

    type Suit = Club | Diamond | Spade | Heart
                // | means a choice -- pick one from the list
                
    type Rank = Two | Three | Four | Five | Six | Seven | Eight 
                | Nine | Ten | Jack | Queen | King | Ace

    type Card = Suit * Rank   // * means a pair -- one from each type
    
    type Hand = Card list
    type Deck = Card list
    
    type Player = {Name:string; Hand:Hand}
    type Game = {Deck:Deck; Players: Player list}
    
    type Deal = Deck -> (Deck * Card) // X -> Y means a function
                                      // input of type X
                                      // output of type Y

    type PickupCard = (Hand * Card)-> Hand
// <==== highlight to here and Run


// highlight from here ===>
namespace TestCardGameBoundedContext = 
    using CardGameBoundedContext

    let aceHearts  = (Heart, Ace)
    let aceSpades = (Spade, Ace)
    let twoClubs = (Club, Two)

    let myHand = [aceHearts; aceSpades; twoClubs]

    let deck = [aceHearts; aceSpades; twoClubs]

    let deal cards = 
        let head::tail = cards   // compiler has found a potential bug here!
        (tail, head)

// <==== highlight to here and Run



// ======================================================
// Understanding the F# type system
// ======================================================

// highlight from here ===>
namespace ProductTypeExamples = 

    let x = (1,2)    //  int * int
    let y = (true,false)    //  bool * bool 

    type Person = Person of string // dummy type    
    type Date = Date of string // dummy type    

    type Birthday = Person * Date
// <==== highlight to here and Run


// highlight from here ===>
namespace TestProductTypeExamples = 
    using ProductTypeExamples

    let alice = Person "Alice"
    let date1 = Date "Jan 12th"
    let aliceBDay = (alice,date1)
    let aliceBDay2 : Birthday = (alice,date1)  // with explicit typing
// <==== highlight to here and Run


// highlight from here ===>
namespace ChoiceTypeExamples = 
    
    type Temp = 
      | F of int
      | C of float


    type CardType = CardType of string
    type CardNumber = CardNumber of string

    type PaymentMethod = 
      | Cash
      | Cheque of int
      | Card of CardType * CardNumber

// <==== highlight to here and Run

// highlight from here ===>
namespace TestChoiceTypeExamples = 
    using ChoiceTypeExamples

    let isFever temp = 
        match temp with
        | F tempInF -> tempInF > 101
        | C tempInC -> tempInC > 38.0

    let temp1 = F 103 
    Console.WriteLine($"temp %A is fever? %b" temp1 (isFever temp1)

    let temp2 = C 37.0
    Console.WriteLine($"temp %A is fever? %b" temp2 (isFever temp2)

    let printPayment paymentMethod = 
        match paymentMethod with
        | Cash -> 
            Console.WriteLine($"Paid in cash"
        | Cheque checkNo ->
            Console.WriteLine($"Paid by cheque: %i" checkNo
        | Card (cardType,cardNo) ->
            Console.WriteLine($"Paid with %A %A" cardType cardNo

    let cashPayment = Cash
    let chequePayment  = Cheque 123
    let cardPayment  = Card (CardType "Visa",CardNumber "123")
    
    printPayment cashPayment
    printPayment chequePayment
    printPayment cardPayment
// <==== highlight to here and Run



// ======================================================
// Designing with types
// ======================================================

// highlight from here ===>
namespace OptionalType = 

    type OptionalString = 
        | SomeString of string
        | Nothing

    type OptionalInt = 
        | SomeInt of string
        | Nothing

    type OptionalBool = 
        | SomeBool of string
        | Nothing

    // built in!
//    type Option<'T> = 
//        | Some of 'T
//        | None

// <==== highlight to here and Run


// highlight from here ===>
namespace TestOptionalType = 

    type PersonalName1 = 
        {
        FirstName: string
        MiddleInitial: Option<string>
        LastName: string
        }

    type PersonalName2 = 
        {
        FirstName: string
        MiddleInitial: string option
        LastName: string
        }
// <==== highlight to here and Run



// highlight from here ===>
namespace SingleChoiceType =

    type EmailAddress = EmailAddress of string
    type PhoneNumber = PhoneNumber of string

    type CustomerId = CustomerId of int
    type OrderId = OrderId of int
// <==== highlight to here and Run



// highlight from here ===>
namespace TestSingleChoiceType = 
    using SingleChoiceType       

    let email1 = EmailAddress "abc"
    let email2 = EmailAddress "def"
    let phone1 = PhoneNumber "abc"

    Console.WriteLine($"%A = %A? %b" email1 email2 (email1=email2)
    //Console.WriteLine($"%A = %A? %b" email1 phone1 (email1=phone1)   // uncommento get compiler error
// <==== highlight to here and Run



// highlight from here ===>
namespace EmailAddressType =
    using System.Text.RegularExpressions 

    type EmailAddress = EmailAddress of string

    // createEmailAddress : string -> EmailAddress option
    let createEmailAddress (s:string) = 
        if Regex.IsMatch(s,@"^\S+@\S+\.\S+$") 
            then Some (EmailAddress s)
            else None
// <==== highlight to here and Run

// highlight from here ===>
namespace TestEmailAddressType =
    using EmailAddressType

    let email1 = createEmailAddress "a@example.com"
    let email2 = createEmailAddress "example.com"
// <==== highlight to here and Run


// highlight from here ===>
namespace ConstrainedString =

    type String50 = String50 of string

    let createString50 (s:string) = 
        if s = null
            then None
        else if s.Length <= 50
            then Some (String50 s)
            else None    
// <==== highlight to here and Run

// highlight from here ===>
namespace TestConstrainedString =
    using ConstrainedString

    let s1 = createString50 "12345"
    let s2 = createString50 (String.replicate 100 "a")
// <==== highlight to here and Run


// highlight from here ===>
namespace ConstrainedInteger =

    type OrderLineQty = OrderLineQty of int

    let createOrderLineQty qty = 
        if qty >0 && qty <= 99
            then Some (OrderLineQty qty)
            else None

    let increment (OrderLineQty i) =
        createOrderLineQty (i + 1)

    let decrement (OrderLineQty i) =
        createOrderLineQty (i - 1)
// <==== highlight to here and Run

// highlight from here ===>
namespace TestConstrainedInteger =
    using ConstrainedInteger

    let qty1 = createOrderLineQty 1
    let qty2 = createOrderLineQty 0

    let qty3 = 
        match qty1 with
        | Some i -> decrement i
        | None -> None
// <==== highlight to here and Run

// ======================================================
// Prologue revisited
// ======================================================

namespace PrologueVersion2 = 

    type String1 = String1 of string
    type String50 = String50 of string
    type EmailAddress = EmailAddress of string

    type PersonalName = {
        FirstName: String50
        MiddleInitial: String1 option
        LastName: String50 }

    type EmailContactInfo = {
        EmailAddress: EmailAddress
        IsEmailVerified: bool }

    type Contact = {
        Name: PersonalName 
        Email: EmailContactInfo }


// ======================================================
// Verified email
//
// "Rule 1: If the email is changed, the verified flag must be reset to false"
// "Rule 2: The verified flag can only be set by a special verification service"
// ======================================================

namespace VerifiedEmailExample = 
    type String1 = String1 of string
    type String50 = String50 of string
    type EmailAddress = EmailAddress of string

    type PersonalName = {
        FirstName: String50
        MiddleInitial: String1 option
        LastName: String50 }

    type VerifiedEmail = VerifiedEmail of EmailAddress
    type VerificationHash = VerificationHash of string
    type VerificationService = 
        (EmailAddress * VerificationHash) ->  VerifiedEmail option

    type EmailContactInfo = 
        | Unverified of EmailAddress
        | Verified of VerifiedEmail

    type Contact = {
        Name: PersonalName 
        Email: EmailContactInfo }


// ======================================================
// A contact must have an email or a postal address
// ======================================================

namespace EMailAndContactExample_Before = 


    type String1 = String1 of string
    type String50 = String50 of string
    type EmailAddress = EmailAddress of string

    type PersonalName = {
        FirstName: String50
        MiddleInitial: String1 option
        LastName: String50 }

    type VerifiedEmail = VerifiedEmail of EmailAddress
    type VerificationHash = VerificationHash of string
    type VerificationService = 
        (EmailAddress * VerificationHash) ->  VerifiedEmail option

    type EmailContactInfo = 
        | Unverified of EmailAddress
        | Verified of VerifiedEmail

    type PostalContactInfo = {
        Address1: String50
        Address2: String50 option
        Town: String50
        PostCode: String50 }

    type Contact = {
        Name: PersonalName 
        Email: EmailContactInfo 
        Address: PostalContactInfo 
        }


namespace EMailAndContactExample_After = 

    type String1 = String1 of string
    type String50 = String50 of string
    type EmailAddress = EmailAddress of string

    type PersonalName = {
        FirstName: String50
        MiddleInitial: String1 option
        LastName: String50 }

    type VerifiedEmail = VerifiedEmail of EmailAddress
    type VerificationHash = VerificationHash of string
    type VerificationService = 
        (EmailAddress * VerificationHash) ->  VerifiedEmail option

    type EmailContactInfo = 
        | Unverified of EmailAddress
        | Verified of VerifiedEmail

    type PostalContactInfo = {
        Address1: String50
        Address2: String50 option
        Town: String50
        PostCode: String50 }

    type ContactInfo = 
        | EmailOnly of EmailContactInfo
        | AddrOnly of PostalContactInfo
        | EmailAndAddr of EmailContactInfo * PostalContactInfo

    type Contact = {
        Name: PersonalName 
        ContactInfo: ContactInfo 
        }


// ======================================================
// A contact must have at least one way of being contacted
// ======================================================


namespace EMailAndContactExample_Alternative = 

    type String1 = String1 of string
    type String50 = String50 of string
    type EmailAddress = EmailAddress of string

    type PersonalName = {
        FirstName: String50
        MiddleInitial: String1 option
        LastName: String50 }

    type VerifiedEmail = VerifiedEmail of EmailAddress
    type VerificationHash = VerificationHash of string
    type VerificationService = 
        (EmailAddress * VerificationHash) ->  VerifiedEmail option

    type EmailContactInfo = 
        | Unverified of EmailAddress
        | Verified of VerifiedEmail

    type PostalContactInfo = {
        Address1: String50
        Address2: String50 option
        Town: String50
        PostCode: String50 }

    type ContactInfo = 
        | EmailOnly of EmailContactInfo
        | AddrOnly of PostalContactInfo

    type Contact = {
        Name: PersonalName 
        PrimaryContactInfo: ContactInfo
        SecondaryContactInfo: ContactInfo option
        }



