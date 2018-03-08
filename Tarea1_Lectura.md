# C# 5: Async / Await
#### Lectura original: https://geeks.ms/etomas/2011/09/17/c-5-async-await/ 

##### Resumen:
C# 5.0 y versiones superiores permiten ejecutar llamadas a métodos asincrónicos usando una sintaxis fácil de leer y entender.
La palabra reservada “async” permite que un método ejecute una operación asincrónica desde el cuerpo del método. Es importante aclarar que el método no es asincrónico si solo se agrega la palabra clave en la declaración.

La palabra reservada “await” permite que un método espere la respuesta de otro método asíncrono y continúe con la ejecución al recibir el resultado de la operación asincrónica.  El método asíncrono debe retornar un objeto especial que pueda ser esperado por otro código. Este objeto será una instancia de la clase Task o Task<T>. La clase Task funciona como un delegate que se ejecuta asincrónicamente. 

Un ejemplo sería declarar una clase llamada Cerveza y crear una función asincrónica para pedir al mesero de un bar la cerveza.
Una método que simula traer la cerveza:

```cs
public Task<Cerveza> ServirCerveza( string nombreDeCerveza )
{
  var result =  new Task<Cerveza>( () => 
  	{
  		// Simulate long process
  		Thread.Sleep(10000);
  		return new Cerveza(nombreDeCerveza);
  	}
  ); 
  result.Start();
  return result;
}
```

El método que simula ejecutar el pedido:

```cs
private async void Button_Click(object sender, RoutedEventArgs e)
{
	var cerveza = await ServirCerveza( txtNombreCerveza.Text );
	DeliverCerveza(cerveza);
}
```