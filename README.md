# What is a TinyType?
* a TinyType is a wrapper of a primitive type
  * so there's two concepts there, wrapper and primitive type
    * a wrapper is a container of something
    * a primitive type is one of the basic data types in C# e.g. int, string, decimal, char, etc.
    * so a tiny type is just a container for a basic data type like string

* Similar to how you build classes to encapsulate the functionality of some kind of noun
  * e.g. Student, Product, Car
* you can do the same thing for primitives

  # Benefits of TinyTypes
   * TinyTypes help you more clearly communicate valid values for an object
     *  e.g. `public string Name` here `Name` is not adequately represented by the `string` primitive type
     *  `Name` can't be empty which is not true of a `string`
     *  we can use a TinyType to add a constraint to `Name` so that it cannot be empty, null, or whitespace (shown in Source folder `TinyTypesExamples` class Name Example region
   * They help you narrow down the set of all possible values
     * e.g. we have a `Drink` class that has a `Size` property. We'll say the `Size` is represented by only a letter and can only be s,m,l,S,M,L
     * if we represent it as a primitive `public char Size` the set of all possible values is all possible characters(`char`)
     * but if we use a TinyType `public DrinkSize Size` and we add a constraint to the TinyType (shown in Source folder `TinyTypeExamples`class DrinkSize example region)
       we can limit the possible values to s,m,l,S,M,L only.
   * TinyTypes make your code more readable
     * it can get difficult to keep track of what primitive type represents what concept, especially if you have many of the same types like `string` or `decimal`
     * distinguishing between similar types helps make your code more clear, and easier to understand quickly
     * Example show in Source folder `TinyTypesExamples` Receipt Example region
   * TinyTypes give you type safety
      * e.g. instead of all your ids being of type Guid which can cause them to be mixed up
          * `public Guid AppointmentId; public Guid PatientId; public Guid DoctorId;`
      * you can differentiate between them
          * `public AppointmentId Id; public PatientId PatientId; public DoctorId DoctorId;`
      * before you could accidentally set the `AppointmentId` as the `PatientId`, or the `PatientId` as the `DoctorId`
      * but making them TinyTypes makes this unable to happen. You can't set a `PatientId` type for a `DoctorId` type
   * Validation: you can't create one that isn't valid, so if you have one you know it's valid (given an always valid Domain)
     ### in a TinyType you are defining exactly what the values can be. You're making a completely unique type that you can use the same as you use primitives

# Implementation
* so before getting into implementation you first need to know somethings about a TinyType
* A TinyType is a special type of Value Object that only has one value
* A Value Object is defined by having 2 types of equality
1. Referential Equality: if you have two objects that point to the same instance then they're equal
    - e.g. `var person = new Person();`  `var person2 = person;`
    - `person` and `person2` have the same reference, they point to the same instance so they have Referential Equality
2. Structural Equality: if all of the values are the same then they're equal, and they don't have to be the same reference
    - e.g. `var sku = new Sku("abc123")`  `var sku2 = new Sku("abc123")`
    - `sku` and `sku2` have the same values, so they have Structural Equality, it doesn't matter which reference we have, only the values matter and they are the same.

* when implementing a TinyType you have to override the `Equals` method which you can see in each of the `TinyTypeExamples` as well as in the `TinyTypes` base class
  * all objects have the `Equals` method on them, and by default it checks referential equality so we override it to check both referential equality and structural equality
  
* now that we've established what a TinyType is, we can model it
  * we can build a generic TinyType class and mark it abstract to force our concrete implementations to inherit it
  * you can see this implementation in the Base folder `TinyType` class.
  * You can see how it's used with the concrete implementations in `BaseImplementations` class within the same folder
 
  # other tips
  * when deciding when to make something a TinyType keep in mind
    * does this value have more than one rule? it should probably be a TinyType
    * are there multiple values using the same primitive type? it should probably be a TinyType to differentiate between them
  * you make the decision on what needs to be a tiny type, there are no defined rules for this only suggestions
