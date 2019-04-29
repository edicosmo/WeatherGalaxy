# WeatherGalaxy

En una galaxia lejana, existen tres civilizaciones. Vulcanos, Ferengis y Betasoides. Cada civilización vive en paz en su respectivo planeta. 

Dominan la predicción del clima mediante un complejo sistema informático. 

**Premisas:**
- El planeta Ferengi se desplaza con una velocidad angular de 1 grados/día en sentido horario. Su distancia con respecto al sol es de 500Km.
- El planeta Betasoide se desplaza con una velocidad angular de 3 grados/día en sentido horario. Su distancia con respecto al sol es de 2000Km.
- El planeta Vulcano se desplaza con una velocidad angular de 5 grados/día en sentido anti-horario, su distancia con respecto al sol es de 1000Km.
- Todas las órbitas son circulares.

**Solucion**

Para el desarrollo de la siguiente Web Api, se utilizo como plataforma .NET Web API 2. El mismo utiliza como legunaje de programacion C#.

Se hosteo en el cloud www.appharbor.com, su Url es la siguiente http://weathergalaxy.apphb.com/

**Condicionantes**

Se utilizaron coordenadas cartesianas para realizar los calculos matematicos en las posiciones de los planetas. Al utilizar tipos double, tomamos solamente 1 decimal despues de la coma con el fin de ajustar la precision de las posiciones.

**Prueba**

Por cuestiones de infraestructura en appharbor.com nos genera conflictos para utilizar Swagger. Por lo que recomendamos la utilizacion de cualquier cliente http en su reemplazo, ejemplo [Postman](https://www.getpostman.com/).

Se desarrollo una API REST para consultar las siguientes preguntas

1. ¿Cuántos períodos de sequía habrá?
2. ¿Cuántos períodos de lluvia habrá y qué día será el pico máximo de lluvia?
3. ¿Cuántos períodos de condiciones óptimas de presión y temperatura habrá?

Para su prueba, la URL de consulta es la siguiente:

GET http://weathergalaxy.apphb.com/api/Galaxy/GetWeatherResume

**Resultado:**
```JSON
{
    "DroughtDays": 110,
    "RainDays": 1196,
    "OptimalDays": 40,
    "RainPeakDay": 22,
    "MaxPerimeter": 6,
    "UnknownDays": 2254
}
```

Ademas, contamos con otra API que puede consultar el clima para un dia especifico.

GET http://weathergalaxy.apphb.com/api/Galaxy/Clima?day=566
```JSON
{
    "Day": 566,
    "Weather": "Lluvia"
}
```
