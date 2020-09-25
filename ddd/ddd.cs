

// ======================================================
// This page contains C# code snippets adapted from the talk
// "Domain-driven design with the F# type system"
// A helper set of classes are contained in the accompanying Choice.cs to enable "Choice" types
// (also known as discriminated unions)
// ======================================================

// To execute code in Visual Studio Code Insiders Preview, 
//  (a) install the .NET Interactive plugin
//  (b) Highlight code, right click and choose "Send to Interactive"

// Try it! highlight from here ===>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using DiscriminatedUnions;

var three = 1 + 2;
Func<double, double> square = x => x * x;
Console.WriteLine($"Three is {three}");
Console.WriteLine($"Three is {square(three)}");
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
    class Example
    {
        void Test()
        {
            var alice = new PersonalName(FirstName: "Alice", LastName: "Adams");
            var aliceClone = new PersonalName(FirstName: "Alice", LastName: "Adams");
            Console.WriteLine($"Alice's name is {alice}");
            Console.WriteLine($"AliceClone's name is {aliceClone}");
            Console.WriteLine($"Are Alice and clone equal? {alice == aliceClone}");
        }
    }
}
// <==== highlight to here and Run 

// NOTE you may need to scroll up in the outpt window to see the print statements



// ======================================================
// demonstration of Entity types in C#
// ======================================================

// highlight from here ===>
// define the type
namespace EntityTypeExample {

    // class with immutable members, compared by member value
    record PersonalName(string FirstName, string LastName);

    // class with immutable members, compared by custom member logic (lack of parity between conciseness of entities and records)
    class Person
    {
        public int Id { get; init; } 
        public PersonalName Name { get; init; }

        // required properties coming in C# 10 (for now, constrain inputs with parameterized constructor)
        public Person(int Id, PersonalName Name) // using upper-case to match record constructor
        {
            this.Id = Id;
            this.Name = Name;
        }

        public override bool Equals(object other) => other switch
        {
            Person p => Id == p.Id,
            _ => false
        };

        public override int GetHashCode() => this.Id.GetHashCode();
    }
    
    class Example
    {
        void Test()
        { 
            var alice = new Person( 1, new PersonalName(FirstName: "Alice", LastName: "Adams") );
            var bilbo = new Person( 1, new PersonalName(FirstName: "Bilbo", LastName: "Baggins") );
            Console.WriteLine($"Alice is {alice}");
            Console.WriteLine($"Bilbo is {bilbo}");
            Console.WriteLine($"Are Alice and Bilbo equal? {alice == bilbo}");
            Console.WriteLine($"Are Alice.Name and Bilbo.Name equal? {alice.Name == bilbo.Name}");
        }
    }
}
// <==== highlight to here and Run


// ======================================================
// Record versioning in C#
// ======================================================

// highlight from here ===>
// define the type
namespace RecordVersioningExample {

    // class with immutable members, compared by member value
    record PersonalName(string FirstName, string LastName);

    // class with immutable members, compared by member value
    record Person(int Id, Guid Version, PersonalName Name);

    class Example
    {
        void Test()
        {
            var alice = new Person(Id: 1, Version: Guid.NewGuid(), 
                Name: new(FirstName: "Alice", LastName: "Adams"));

            var aliceV2 = alice with
            { 
                Version = Guid.NewGuid(),
                Name = new PersonalName(FirstName: "Al", LastName:"Adamson")
            };
    
            Console.WriteLine($"Alice is {alice}");
            Console.WriteLine($"AliceV2 is {aliceV2}");
            Console.WriteLine($"Are Alice and AliceV2 equal? {alice == aliceV2}"); // no compiler error in C#, unlike F#
            Console.WriteLine($"Are Alice and AliceV2 same id? {alice.Id == aliceV2.Id}");
            Console.WriteLine($"Are Alice and AliceV2 same version? {alice.Version == aliceV2.Version}");
        }
    }
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
    record Person(int Id){ public PersonalName? Name { get; set; } } 

    class Example
    {
        void Test()
        {
            var alice = new Person(Id: 1){ Name = new PersonalName(FirstName: "Alice", LastName: "Adams") };
            Console.WriteLine($"Alice before change is {alice}");
                
            alice.Name = new PersonalName(FirstName: "Al", LastName: "Adamson");
            Console.WriteLine($"Alice after change is {alice}");
        }
    }
}
// <==== highlight to here and Run

// ======================================================
// Review of code so far
// ======================================================

// highlight from here ===>
namespace ValueAndEntityReview { 

    record PersonalName(string FirstName, string LastName); // an immuntable object compared by value

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
namespace CardGameBoundedContext {

    // | means a choice -- pick one from the list
    using Suit = Choice<Club, Diamond, Spade, Heart>;
    using Rank = Choice<Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace>;
    using Hand = List<Card>;
    using Deck = List<Card>;

    record Card(Suit Suit, Rank Rank);   // * means a pair -- one from each type
    record Club; record Diamond; record Spade; record Heart;
    record Two; record Three; record Four; record Five; record Six; record Seven; record Eight; 
        record Nine; record Ten; record Jack; record Queen; record King; record Ace;

    record Player(string Name, Hand Hand);
    record Game(Deck Deck, Player[] Players);
    delegate (Deck, Card) Deal(Deck d);
    delegate Hand PickupCard((Hand, Card) handCardTuple);
    // Func<Deck, (Deck, Card)> Deal; // works only in class or interface scope
    // Func<(Hand, Card), Hand> PickupCard; // works only in class or interface scope

    class Example
    {
        void Test()
        {
            var aceHearts  = new Card(new Heart(), new Ace());
            var aceSpades = new Card(new Spade(), new Ace());
            var twoClubs = new Card(new Club(), new Two());

            var myHand = new Hand { aceHearts, aceSpades, twoClubs };

            var deck = new Deck { aceHearts, aceSpades, twoClubs };

            Func<Deck, (Deck?, Card)> deal = deck => deck switch
            {
                Deck d when d.Count() > 1   => (d.Take(d.Count() - 1).ToList(), d.Last()),
                Deck d when d.Count() == 1  => (null, d[0]),
                _                           => throw new ArgumentException("incorrect input")
            };

            (var deck2, var card) = deal(deck);
    }
}

// <==== highlight to here and Run



// ======================================================
// Understanding the C# type system and use of custom Choice<T1, T2, ...> union type
// ======================================================

// highlight from here ===>
namespace ProductTypeExamples {
    using Person = String; // dummy type 
    using Date = String; // dummy type    
    record Birthday(Person Person, Date Date);

    class Example
    {
        void Test()
        {
            var x = (1,2);    //  ValueTuple<int, int>
            var y = (true,false);    //  ValueTuple<bool, bool>

            var alice = new Person("Alice");
            var date1 = new Date("Jan 12th");
            var aliceBDay = new Birthday(alice,date1);
            Birthday aliceBDay2 = new (alice,date1);  // with target typing
            Birthday aliceBDay3 = new Birthday(alice, date1);  // with fully explicit typing
        }
    }
}
// <==== highlight to here and Run


// highlight from here ===>
namespace ChoiceTypeExamples{

    using Temp = Choice<F, C>;

    using CardType = Choice<Visa, MasterCard>;
    using CardNumber = Int32;
    using ChequeNumber = Int32;

    using PaymentMethod = Choice<Cash, Cheque, Card>;

    record F(int Value);
    record C(double Value);
    record Cash;
    record Cheque(ChequeNumber ChequeNumber);
    record Card(CardType CardType, CardNumber CardNumber);
    record Visa;
    record MasterCard;

    class Example
    {
        void Test()
        {
            Func<Temp, bool> isFever = temp => temp.Item switch // dynamically-typed in C# impl
                {
                    F tempInF => tempInF.Value > 101,
                    C tempInC => tempInC.Value > 38.0,
                    _ => throw new ArgumentException()
                };

            var temp1 = new F(103);
            Console.WriteLine($"temp {temp1} is fever? {isFever(temp1)}");

            var temp2 = new C(37.0);
            Console.WriteLine($"temp {temp2} is fever? {isFever(temp2)}");

            Action<PaymentMethod> printPayment = paymentMethod => 
                Console.WriteLine(paymentMethod.Item switch
                {
                    Cash          => $"Paid in cash",
                    Cheque cheque => $"Paid by cheque: {cheque.ChequeNumber}",
                    Card card     => $"Paid with {card.CardType} {card.CardNumber}",
                    _             => throw new ArgumentException()
                });

            var cashPayment = new Cash();
            var chequePayment = new Cheque(123);
            var cardPayment = new Card (new Visa(), 123);
    
            printPayment(cashPayment);
            printPayment(chequePayment);
            printPayment(cardPayment);
        }
    }
}
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



