## 1. Información General
- **Nombre del proyecto:** schoolsena (Repositorio `Tangamandapio.git`)
- **Versión evaluada:** 1.0 (Build StandaloneWindows64)
- **Motor y Pipeline:** Unity 2022.3.62f3 LTS – Universal Render Pipeline (URP)
- **Equipo responsable:** Jesús Alberto Salazar Gaitán, Miguel Ángel Murcia Yagüe, David Alejandro Montañez Torres
- **Ficha:** 3171050 | **Instructor:** Eddier Yair Liberato Cuenca
- **Fecha de ejecución:** 06 de noviembre de 2026

## 2. Entorno de Pruebas (Hardware y Software)
- **Sistema Operativo:** Windows 10 / 11 de 64 bits
- **Procesador y RAM:** Intel Core i3 (11.ª Gen) / Core i5, 8 GB de RAM
- **Tarjeta Gráfica:** Compatible con DirectX 11
- **Resolución de prueba:** 1920 × 1080 (Full HD)
- **Herramientas de diagnóstico:** Unity Profiler, Consola de Unity y Funplay Unity MCP (`audit_ui`)

## 3. Matriz de Casos de Prueba Funcionales (Ejecución en Editor y Build)

| ID | Caso de prueba | Pasos de ejecución | Resultado esperado | Resultado obtenido | Estado |
| :--- | :--- | :--- | :--- | :--- | :--- |
| **CP-01** | Menú a Nivel 1 (Hub) | Abrir `schoolsena.exe` y pulsar `Play` en `MainMenu` | Carga el Hub (`Nivel 1`) sin errores y muestra bienvenida | Carga correcta en 1920×1080 | **Aprobado** |
| **CP-02** | Diálogo con NPC | Acercarse a un instructor en el Hub con `W, A, S, D` | El movimiento se pausa y aparece el panel de orientación | Pausa activa y diálogo visible | **Aprobado** |
| **CP-03** | Filtro Quiz (3 preguntas) | Elegir opción errónea y luego acertar las 3 preguntas (A-D) | Botón en ámbar (0,5 s), rojo en error y desbloqueo con 3 verdes | Semáforo funcional y desbloqueo correcto | **Aprobado** |
| **CP-04** | Minijuego Electricidad | Girar las 7 filas de cables antes de que acaben los 120 s | Sonido de chispa al alinear fila y foco encendido al completar | Circuito validado; tiempo medio 1 min 21 s | **Aprobado** |
| **CP-05** | Minijuego Multimedia | Tomar 8 fotos con tecla `E` respetando los 3 s de enfriamiento | Contador sube a `8/8` y se despliega el Álbum final | Capturas almacenadas y mostradas en UI | **Aprobado** |
| **CP-06** | Módulos Fase 2 y Cierre | Verificar reserva de puertas (Nivel 4 y 5) y salida con `Quit` | Puertas reservadas en Hub y cierre limpio de aplicación | Ejecución sin errores en consola | **Aprobado** |

## 4. Pruebas de Rendimiento y Optimización Técnica
Se aplicaron cuatro técnicas de optimización: **Universal Render Pipeline (URP)**, **Lightmaps precalculados (Baking)**, **Occlusion Culling** y uso de **84 Prefabs**.

| Métrica / Indicador | Antes de optimizar | Después de optimizar | Meta del proyecto | Estado |
| :--- | :--- | :--- | :--- | :--- |
| **FPS Promedio (1080p)** | 41 FPS | 58 FPS | 30 – 60 FPS | **Cumplido** |
| **FPS Mínimo (1% low)** | 28 FPS | 47 FPS | ≥ 30 FPS | **Cumplido** |
| **Errores de compilación** | 0 | 0 | 0 errores en consola | **Cumplido** |

## 5. Pruebas con Usuarios (Validación Preliminar - Muestra n = 12)
- **Participantes:** 12 jóvenes entre 16 y 18 años ($M = 16.9$).
- **Claridad vocacional global (Escala 1 a 5):** Subió de **2.6** (Pre-test) a **4.0** (Post-test) ($p = .002$).
- **Tasa de éxito en Filtro Cognitivo:** 58 % de acierto al primer intento (promedio de 1.7 intentos por pregunta).
- **Tasa de finalización:** 10 de 12 completaron Electricidad dentro de los 120 s; 12 de 12 completaron los 8 encuadres de Multimedia.

## 6. Registro de Defectos Corregidos
Los 4 defectos detectados durante las pruebas (dependencia de Git para MCP, orden de índices en Build Settings, aviso `transparent_raycast` en botones de menú y enfriamiento de 3 s en cámara fotográfica) fueron corregidos y trasladados al archivo `CHANGELOG.md` del repositorio.
