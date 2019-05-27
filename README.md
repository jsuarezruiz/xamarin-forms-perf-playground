# Xamarin.Forms Performance Playground

There are many techniques for increasing the **performance** of Xamarin.Forms applications. Collectively these techniques can greatly reduce the amount of work being performed by a CPU, and the amount of memory consumed by an application. This repository describes and discusses these techniques.

_(Work in progress)_

* Bindings
* CollectionView
* Fast Renderers
* HttpClient
* Images
* IoC
* Layouts
* Shell
* Startup
* Visual
* XAMLC

### Fast Renderers

Traditionally, most of the original control renderers on Android are composed of two views:
* A native control, such as a Button or TextView.
* A container ViewGroup that handles some of the layout work, gesture handling, and other tasks.

However, this approach has a performance implication in that two views are created for each logical control, which results in a more complex visual tree that requires more memory, and more processing to render on screen.

Fast renderers **reduce the inflation** and rendering costs of a Xamarin.Forms control into a single view. 

Fast renderers are available for the following controls in Xamarin.Forms on Android:
* Button
* Image
* Label
* Frame

_**NOTE:** [Xamarin.Forms 4 use the Fast Renderers by Default](https://github.com/xamarin/Xamarin.Forms/issues/5724)._

The results:

![Fast Renderers](images/fastrenderersperf.png)

_**NOTE:** Using a Oneplus 6 device with AOT and XAMLC (Release mode)._

### HttpClient

Many mobile applications depend on external data making intensive use of the network. Therefore, we are interested in having the fastest possible response when making HTTP requests.

 Take the approach of using a single **HttpClient** instance per server (**reuse** HttpClient between requests). This will get you better performance.

The results:

![HttpClient](images/httpclientperf.png)

This is because will segregate things each server may depend on such as cookies or DefaultRequestHeaders. 

A common mistake working with HttpClient is to download json to a string. The problem is that this creates a string of your entire JSON document needlessly. 

This has two problems:
* Depending on the size of the downloaded file to chain, it will affect more than the necessary time.
* Higher memory consumption.

Other recommendations:
- Use GZIP (or deflate) where possible.
- Use Xamarin's Native HttpMessageHandlers.

## Bindings

![Bindings](images/bindingsperf.png)

## Images 

![IoC](images/imageperf.png)

### IoC

Comparative performance in the registry and in the dependency resolution of the most used containers when developing with Xamarin.Forms:

![IoC](images/iocperf.png)

_(Work in progress)_

### Layouts

A Layout represents a node in the visual tree. A Layout has properties and events that allow to define its behavior.

It is responsible for managing the location and size of secondary nodes.

Examples: StackLayout, Grid, etc.

![Layouts](images/xamarinformslayouts.png)

The creation of a Xamarin.Forms layout goes through two phases:
* **Invalidation** cycle: The process of recursive notification to the parent node.
* **Layout** cycle: After invalidating, we proceed to the reorganization of elements marked as _"invalidated"_.

The Invalidation cycle:
![Invalidation](images/layoutinvalidation.png)

The Layout cycle:
![Layout](images/layout.png)

In the following chart we have the time in milliseconds of **UpdateChildrenLayout** in each Layout. The example to render:

The result:

![Layouts](images/layoutsperf.png)

**Grid**

The Grid organizes child elements into rows and columns. It allows to create complex structures without the need for large nests.

The size of each row and column is important, and affects performance. We must take care of the use of cells and rows.

**StackLayout**

The StackLayout organizes views in a one-dimensional line ("stack"), either horizontally or vertically. Views in a StackLayout can be sized based on the space in the layout using layout options. Positioning is determined by the order views were added to the layout and the layout options of the views.

It can lead to **excessive nesting**.

The invalidation of a child View causes the chain invalidation in the visual tree until the StackLayout.

**RelativeLayout**

The RelativeLayout organizes the child elements based on relationships between the different elements and the container. Ideal when the size or positioning should be dynamic and adapt to different conditions.

It is the layout with lowest performance. High CPU consumption.

Other Recommendations:
* Do not use StackLayout for just one child.
* Do not use StackLayout when you can use Grid.
* Do not nest several StackLayouts when you can use a Grid.
* The RelativeLayout gives many possibilities but its performance is worse than the FlexLayout.

### Startup

JIT, AOT and other concepts have an impact on the startup time of the App.

Ahead of Time Compilation builds everything upfront, to avoid JIT when first running your app. When this option is enabled, Just In Time (JIT) startup overhead is minimized by precompiling assemblies before runtime. The resulting native code is included in the APK along with the uncompiled assemblies. This results in shorter application startup time, but at the expense of slightly larger APK sizes.

![Startup](images/startupperf.png)

![Startup Sizes](images/startupsizes.png)

_**NOTE:** Using a Oneplus 6 device (Release mode)._

### XAMLC

XAML can be optionally compiled directly into intermediate language (IL) with the XAML compiler (XAMLC).

XAML compilation offers a number of a benefits:

* It performs compile-time checking of XAML, notifying the user of any errors.
* It removes some of the load and instantiation time for XAML elements.
* It helps to reduce the file size of the final assembly by no longer including .xaml files.

```
[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
```
The result:

![XAMLC](images/xamlcperf.png)

## Copyright and license

Code released under the [MIT license](https://opensource.org/licenses/MIT).