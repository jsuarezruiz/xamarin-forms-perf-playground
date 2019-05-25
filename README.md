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
* Views
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

## Images 

![IoC](images/imageperf.png)

### IoC

![IoC](images/iocperf.png)

### Startup

Ahead of Time Compilation builds everything upfront, to avoid JIT when first running your app. When this option is enabled, Just In Time (JIT) startup overhead is minimized by precompiling assemblies before runtime. The resulting native code is included in the APK along with the uncompiled assemblies. This results in shorter application startup time, but at the expense of slightly larger APK sizes.

![Startup](images/startupperf.png)

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