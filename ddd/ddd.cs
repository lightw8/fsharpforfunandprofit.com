#nullable enable

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
    class Example {
        void Test() {
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
    class Person {
        public int Id { get; init; } 
        public PersonalName Name { get; init; }

        // required properties coming in C# 10 (for now, constrain inputs with parameterized constructor)
        public Person(int Id, PersonalName Name) // using upper-case to match record constructor
        {
            this.Id = Id;
            this.Name = Name;
        }

        public override bool Equals(object? other) =>
            other switch
            {
                Person p => Id == p.Id,
                _        => false
            };

        public override int GetHashCode() => this.Id.GetHashCode();
    }
    
    class Example {
        void Test() { 
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

    class Example {
        void Test() {
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

    class Example {
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

        public Person(int id, PersonalName name)
        {
            Id = id;
            Name = name;
        }
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

            Func<Deck, (Deck?, Card)> deal = deck => 
                deck switch
                {
                    Deck d when d.Count() > 1   => (d.Take(d.Count() - 1).ToList(), d.Last()),
                    Deck d when d.Count() == 1  => (null, d[0]),
                    _                           => throw new ArgumentException("incorrect input")
                };

            (var deck2, var card) = deal(deck);
        }
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
namespace ChoiceTypeExamples {

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
            Func<Temp, bool> isFever = temp => 
                temp.Item switch // dynamically-typed in C# impl
                {
                    F tempInF => tempInF.Value > 101,
                    C tempInC => tempInC.Value > 38.0,
                    _         => throw new ArgumentException()
                };

            var temp1 = new F(103);
            Console.WriteLine($"temp {temp1} is fever? {isFever(temp1)}");

            var temp2 = new C(37.0);
            Console.WriteLine($"temp {temp2} is fever? {isFever(temp2)}");

            Action<PaymentMethod> printPayment = paymentMethod => Console.WriteLine(
                paymentMethod.Item switch
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
namespace OptionalType {

    class Example
    {
        Nullable<int> optionalInt1; // either int or null
        Nullable<bool> optionalBool1; // either bool or null
        int? optionalInt2; // built-in syntax
        bool? optionalBool2; // built-in syntax

        string? optionalString; // only useful with C#8 nullable reference type annotations (compiler warning, not error)
    }

    // only useful with C#8 nullable reference type annotations (compiler warning, not error)
    record PersonalName1(string FirstName, string? MiddleInitial, string LastName);
    // alternative, but no construction constraints. C# 10 promises required properties
    record PersonalName2
    {
        public string FirstName { get; init; } // could be null if not supplied in object initializer
        public string? MiddleInitial { get; init; } // explicitly allowed to be null
        public string LastName { get; init; } // could be null if not supplied in object initializer
    }
}
// <==== highlight to here and Run



// highlight from here ===>
namespace SingleChoiceType {

    // option using aliases
    // EmailAddress and PhoneNumber not distinct to C# compiler
    // can't "chain" aliases (e.g. 'using VerifiedEmail = EmailAddress' generates a C# compiler error)
    using EmailAddress = String;
    using PhoneNumber = String;
    using CustomerId = Int32;
    using OrderId = Int32;

    // alternative option using single "choice" type (EmailAddress and PhoneNumber still not distinct to C# compiler)
    using EmailAddress2 = Choice<string>;
    using PhoneNumber2 = Choice<string>;
    using CustomerId2 = Choice<int>; // reference type with integer member "Item"
    using OrderId2 = Choice<int>; // reference type with integer member "Item"

    // distinct classes that can't be confused at compile-time (have to use subclassing in C# to get this type checking)
    // C# 10 promises primary constructors for classes (as with the new record types)
    class EmailAddress3 : Choice<string> { public EmailAddress3(string emailAddress) : base(emailAddress) { } }
    class PhoneNumber3 : Choice<string> { public PhoneNumber3(string phoneNumber) : base(phoneNumber) { } }

    class Example
    {
        void Test()
        {
            // example with aliases for built-in types
            var email1a = new EmailAddress("abc");
            var email1b = new EmailAddress("def");
            var phone1 = new PhoneNumber("abc");
            Console.WriteLine($"{email1a} == {email1b}? {email1a == email1b}");
            Console.WriteLine($"{email1a} == {phone1}? {email1a == phone1}"); // no compiler error with aliases only

            // example with aliases to single-choice type
            var email2a = new EmailAddress2("abc");
            var email2b = new EmailAddress2("def");
            var phone2 = new PhoneNumber2("abc");
            Console.WriteLine($"{email2a} == {email2b}? {email2a == email2b}");
            Console.WriteLine($"{email2a} == {phone2}? {email2a == phone2}"); // no compiler error with aliases only

            // example with 
            var email3a = new EmailAddress3("abc");
            var email3b = new EmailAddress3("def");
            var phone3 = new PhoneNumber3("abc");
            Console.WriteLine($"{email3a} == {email3b}? {email3a == email3b}");
            //Console.WriteLine($"{email3a} == {phone3}? {email3a == phone3}"); // compiler error if uncommented
        }
    }
}
// <==== highlight to here and Run



// highlight from here ===>
namespace EmailAddressType {
    using System.Text.RegularExpressions;
    class EmailAddress : Choice<string> { public EmailAddress(string emailAddress) : base(emailAddress) { } }
    // alternatively, "using EmailAddress = String;", but string and EmailAddress types won't be distinct to the compiler

    class Example
    {
        void Test()
        { 
            // function createEmailAddress : string => EmailAddress?
            Func<string, EmailAddress?> createEmailAddress = s => 
                s switch
                {
                    string maybeEmail when Regex.IsMatch(maybeEmail, @"^\S+@\S+\.\S+$") => new EmailAddress(maybeEmail),
                    _                                                                   => null
                };

            // method with same signature (harder to pass it around)
            EmailAddress? CreateEmailAddress(string s) =>
                s switch
                {
                    string maybeEmail when Regex.IsMatch(maybeEmail, @"^\S+@\S+\.\S+$") => new EmailAddress(maybeEmail),
                    _                                                                   => null
                };

            var email1 = createEmailAddress("a@example.com");
            var email2 = createEmailAddress("example.com");
            var email3 = CreateEmailAddress("a@example.com");
            var email4 = CreateEmailAddress("example.com");
        }
    }
}
// <==== highlight to here and Run


// highlight from here ===>
namespace ConstrainedString {
    class String50 : Choice<string> { public String50(string s) : base(s) { } }

    class Example
    {
        void Test()
        {
            // function createEmailAddress : string => EmailAddress option
            Func<string, String50?> createString50 = s =>
                s switch
                {
                    string maybeString50 when maybeString50.Length <= 50 => new String50(maybeString50),
                    _                                                    => null
                };

            var s1 = createString50("12345");
            var s2 = createString50(new string(Enumerable.Range(0,100).Select(_ => 'a').ToArray()));
        }
    }
}
// <==== highlight to here and Run


// highlight from here ===>
namespace ConstrainedInteger {
    class OrderLineQty : Choice<int> { public OrderLineQty(int qty) : base(qty) { } }
    
    class Example
    {
        void Test()
        { 
            // function createEmailAddress : string => EmailAddress option
            Func<int, OrderLineQty?> createOrderLineQty = qty =>
                qty switch 
                {
                    > 0 and <= 99 => new OrderLineQty(qty),
                    _             => null
                };

            // function createEmailAddress : string => EmailAddress option
            Func<OrderLineQty, OrderLineQty?> increment = qty => createOrderLineQty(qty.Item + 1);
            Func<OrderLineQty, OrderLineQty?> decrement = qty => createOrderLineQty(qty.Item - 1);

            var qty1 = createOrderLineQty(1);
            var qty2 = createOrderLineQty(0);
            var qty3 = qty1 switch
            {
                OrderLineQty i => decrement(i),
                _              => null
            };
        }
    }
}
// <==== highlight to here and Run

// ======================================================
// Prologue revisited
// ======================================================

namespace PrologueVersion2 {

    class String1 : Choice<string> { public String1(string s) : base(s) { } }
    class String50 : Choice<string> { public String50(string s) : base(s) { } }
    class EmailAddress : Choice<string> { public EmailAddress(string s) : base(s) { } }

    record PersonalName(
        String50 FirstName,
        String1? MiddleInitial,
        String50 LastName);

    record EmailContactInfo(
        EmailAddress EmailAddress,
        bool IsEmailVerified);

    record Contact(
        PersonalName Name,
        EmailContactInfo Email);
}

// ======================================================
// Verified email
//
// "Rule 1: If the email is changed, the verified flag must be reset to false"
// "Rule 2: The verified flag can only be set by a special verification service"
// ======================================================

namespace VerifiedEmailExample {

    using EmailContactInfo = Choice<EmailAddress, VerifiedEmail>;

    class String1 : Choice<string> { public String1(string s) : base(s) { } }
    class String50 : Choice<string> { public String50(string s) : base(s) { } }
    class EmailAddress : Choice<string> { public EmailAddress(string s) : base(s) { } }

    record PersonalName(
        String50 FirstName,
        String1? MiddleInitial,
        String50 LastName);

    class VerifiedEmail : Choice<EmailAddress> { public VerifiedEmail(EmailAddress s) : base(s) { } }
    class VerificationHash : Choice<string> { public VerificationHash(string s) : base(s) { } }
    delegate VerifiedEmail? VerificationService(EmailAddress address, VerificationHash hash);

    record Contact(
        PersonalName Name,
        EmailContactInfo Email);
}

// ======================================================
// A contact must have an email or a postal address
// ======================================================

namespace EMailAndContactExample_Before {

    using EmailContactInfo = Choice<EmailAddress, VerifiedEmail>;

    class String1 : Choice<string> { public String1(string s) : base(s) { } }
    class String50 : Choice<string> { public String50(string s) : base(s) { } }
    class EmailAddress : Choice<string> { public EmailAddress(string s) : base(s) { } }

    record PersonalName(
        String50 FirstName,
        String1? MiddleInitial,
        String50 LastName);

    class VerifiedEmail : Choice<EmailAddress> { public VerifiedEmail(EmailAddress s) : base(s) { } }
    class VerificationHash : Choice<string> { public VerificationHash(string s) : base(s) { } }
    delegate VerifiedEmail? VerificationService(EmailAddress address, VerificationHash hash);

    record PostalContactInfo(
        String50 Address1, 
        String50? Address2,
        String50 Town,
        String50 PostCode);
        
    record Contact(
        PersonalName Name,
        EmailContactInfo Email,
        PostalContactInfo Address);
}

namespace EMailAndContactExample_After {

    using ContactInfo = Choice<EmailContactInfo, PostalContactInfo, EmailAndAddress>;

    class String1 : Choice<string> { public String1(string s) : base(s) { } }
    class String50 : Choice<string> { public String50(string s) : base(s) { } }
    class EmailAddress : Choice<string> { public EmailAddress(string s) : base(s) { } }

    record PersonalName(
        String50 FirstName,
        String1? MiddleInitial,
        String50 LastName);

    class VerifiedEmail : Choice<EmailAddress> { public VerifiedEmail(EmailAddress s) : base(s) { } }
    class VerificationHash : Choice<string> { public VerificationHash(string s) : base(s) { } }
    delegate VerifiedEmail? VerificationService(EmailAddress address, VerificationHash hash);

    class EmailContactInfo : Choice<EmailAddress, VerifiedEmail> { 
        public EmailContactInfo(EmailAddress email) : base(email) { }
        public EmailContactInfo(VerifiedEmail verified) : base(verified) { }
    }

    record PostalContactInfo(
        String50 Address1, 
        String50? Address2,
        String50 Town,
        String50 PostCode);

    record EmailAndAddress(EmailAddress EmailAddress, PostalContactInfo PostalContactInfo);
        
    record Contact(
        PersonalName Name,
        ContactInfo ContactInfo);
}

// ======================================================
// A contact must have at least one way of being contacted
// ======================================================

namespace EMailAndContactExample_Alternative {

    class String1 : Choice<string> { public String1(string s) : base(s) { } }
    class String50 : Choice<string> { public String50(string s) : base(s) { } }
    class EmailAddress : Choice<string> { public EmailAddress(string s) : base(s) { } }

    record PersonalName(
        String50 FirstName,
        String1? MiddleInitial,
        String50 LastName);

    class VerifiedEmail : Choice<EmailAddress> { public VerifiedEmail(EmailAddress s) : base(s) { } }
    class VerificationHash : Choice<string> { public VerificationHash(string s) : base(s) { } }
    delegate VerifiedEmail? VerificationService(EmailAddress address, VerificationHash hash);

    class EmailContactInfo : Choice<EmailAddress, VerifiedEmail> { 
        public EmailContactInfo(EmailAddress email) : base(email) { }
        public EmailContactInfo(VerifiedEmail verified) : base(verified) { }
    }
    class ContactInfo : Choice<EmailContactInfo, PostalContactInfo> { 
        public ContactInfo(EmailContactInfo email) : base(email) { }
        public ContactInfo(PostalContactInfo address) : base(address) { }
    }

    record PostalContactInfo(
        String50 Address1, 
        String50? Address2,
        String50 Town,
        String50 PostCode);
        
    record Contact(
        PersonalName Name,
        ContactInfo PrimaryContactInfo,
        ContactInfo? SecondaryContactInfo);
}