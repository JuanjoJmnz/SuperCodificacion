
# Super Codificacion 🧠🔤

Este proyecto es una aplicación de consola en C# que permite codificar y descodificar ficheros de texto mediante un algoritmo de encriptación personalizado.

---

## Descripción

El programa procesa cada línea de un fichero de texto aplicando una serie de transformaciones para codificarlo o descodificarlo, incluyendo:

1. Intercambio de letras entre palabras.
2. Inversión de cada palabra.
3. Rotación cíclica de las palabras.
4. Intercambio espejo (mirror swap) de caracteres.
5. Cifrado César con desplazamiento +3 (para codificar) o -3 (para decodificar).
6. Conversión a mayúsculas en posiciones pares (solo al codificar).

El proceso de decodificación invierte paso a paso estas operaciones para recuperar el texto original.

---

## Uso 🚀

1. Ejecuta la aplicación en consola.
2. Selecciona si deseas **codificar (c)** o **descodificar (d)** un fichero.
3. Introduce el nombre del fichero de texto que quieres procesar.
4. El programa generará un nuevo fichero con el mismo nombre pero añadiendo:
    - `_codificado` antes de la extensión si codificas.
    - `_descodificado` antes de la extensión si decodificas.

Ejemplo: `texto.txt` → `texto_codificado.txt` o `texto_descodificado.txt`

---

## Requisitos 🛠️

- .NET SDK (versión 6.0 o superior recomendada)
- Sistema operativo compatible con .NET (Windows, Linux, macOS)

---

## Estructura del código 📁

- **Codificar(string fichero)**: Lee el fichero original y genera el fichero codificado.
- **Descodificar(string fichero)**: Lee un fichero codificado y genera el fichero descodificado original.
- **MirrorSwap(string input)**: Intercambia los caracteres espejo de una cadena.
- **CifradoCesar(string input, int desplazamiento)**: Aplica un cifrado César con el desplazamiento indicado.
- **MayusculasPosicionesPares(string input)**: Convierte a mayúsculas los caracteres en posiciones pares.
- **Main()**: Entrada principal para seleccionar codificar o decodificar y pedir fichero.

---

## Notas

- El fichero de entrada debe contener texto en minúsculas, sin signos de puntuación para un mejor resultado.
- El programa puede trabajar con archivos con varias líneas.
- El cifrado es simétrico: pasar el archivo codificado por la función de descodificación recupera el original.

---

## Ejemplo rápido

Archivo `texto.txt`:

```
el cielo es muy bonito
```

Después de codificar, el archivo `texto_codificado.txt` podría contener:

```
Oc LiEle Om SuB YonIte
```

Después de descodificarlo, recuperamos el original.

---

## Roadmap 🗺️ 

- [x] Leer archivo de entrada desde consola  
- [x] Escribir archivo de salida con texto codificado/descodificado  
- [x] Intercambiar letras entre palabras según especificación original  
- [x] Invertir cada palabra codificada  
- [x] Aplicar rotación cíclica de palabras  
- [x] Implementar mirror swap (intercambio espejo de caracteres)  
- [x] Añadir cifrado César con desplazamiento +3 / -3  
- [x] Convertir a mayúsculas caracteres en posiciones pares al codificar  
- [x] Implementar descodificación paso a paso para revertir todas las transformaciones  
- [ ] Añadir validación y manejo de errores en lectura/escritura de archivos  
- [ ] Soporte para texto con mayúsculas y signos de puntuación  
- [ ] Permitir personalizar ruta y nombre del archivo de salida  
- [ ] Crear interfaz gráfica sencilla para usuarios no técnicos  
- [ ] Añadir opciones para niveles configurables de codificación (más/menos pasos)  
- [ ] Implementar tests unitarios para cada función de transformación  
- [ ] Optimizar para procesamiento de ficheros grandes  
- [ ] Explorar integración con servicios web para codificación/descodificación remota  

---

## Autor 🙋

Proyecto desarrollado por [Juan José Jiménez Gil](https://github.com/JuanjoJmnz), 2025

## Licencia 📄

Este proyecto está licenciado bajo los términos de la licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.

## Para más

¡Si te ha gustado mi proyecto, dame una estrella o sígueme por GitHub!
