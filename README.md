# Virt-A-Mate Collider Editor

Configures and customizes collisions (rigidbodies and colliders).

> Check out [Collider Editor on Virt-A-Mate Hub](https://hub.virtamate.com/resources/collider-editor.183/)

[Download](https://github.com/acidbubbles/vam-collider-editor/releases) and put the `.var` file in your `AddonPackages` folder.

![Collider Editor Screenshot](https://repository-images.githubusercontent.com/255064702/269db680-956f-11ea-888c-4b4f1cd70b11)

## How to use

Once the plugin has been added to an atom, you will be able to configure the collider. Here's a minimal explanation on the terminology:

- A _rigidbody_ is a shapeless object which is driven by the physics engine. It has weight, velocity and relationships with other rigibodies such as springs.
- A _collider_ is the bounds against which something will collide. While usually attached to a rigidbody to give it a shape, sometimes they are used for custom collisions and are not attached to any rigidbody.
- An _autocollider_ is a custom concept in VaM that allows creating a series of rigidbodies and colliders automatically. This is used for breast and glutes, for example.
- An _autocollidergroup_ is also a custom concept in VaM that drives multiple _autocolliders_ together.
- A _GPU collider_ is a collider that affects hair and clothes.

## Articles

Scroll down to the "Collider Tuner" section, there is an in depth explanation: [vamjapan breast-physics article](https://translate.google.com/translate?depth=1&hl=ja&langpair=ja|en&pto=aue&rurl=translate.google.com&sp=nmt4&u=https://vamjapan.com/breast-physics/)

## Contributors

- [@ProjectCanyon](https://github.com/ProjectCanyon), who completely rewrote the whole thing to repurpose a rigidbody-based implementation to a collider-driven one.

## License

[MIT](LICENSE.md)
