# Changelog – schoolsena (Repositorio Tangamandapio)

Todos los cambios notables, correcciones de errores y auditorías técnicas del proyecto se documentan en este archivo.

## [1.0.0] - 2026-11-06
### Agregado
- Implementación del filtro cognitivo (`QuizManager.cs`) con serie de 3 preguntas de selección múltiple (A, B, C, D) y retroalimentación tipo semáforo (ámbar, rojo, verde).
- Módulos activos y validados: Hub de inducción (`Nivel 1`), Electricidad (`Nivel 2` - 7 filas de cables) y Producción Multimedia (`Nivel 3` - 8 fotografías y álbum).
- Optimización gráfica mediante Universal Render Pipeline (URP), Lightmaps (Baking), Occlusion Culling y 84 Prefabs (incremento de 41 a 58 FPS promedio).
- Documentación oficial completa en español e inglés (Manual Técnico, Manual de Usuario, Manual de Instalación, Propuesta de Diseño y Artículo).

### Corregido (Traslado de la Tabla 9 del Manual Técnico - Errores y Hallazgos)

| N.º | Mensaje o síntoma | Causa | Solución | Prevención |
| :--- | :--- | :--- | :--- | :--- |
| **1** | Error de paquete: `No 'git' executable was found` | El paquete Funplay Unity MCP en `manifest.json` requiere Git instalado | Instalar Git para Windows y reiniciar Unity Hub | Incluir Git como requisito del Escenario B en el Manual de Instalación |
| **2** | Al pulsar Jugar o cruzar puerta carga otra escena | El orden de las escenas en Build Settings no coincidía con los índices | Ordenar las 8 escenas de `MainMenu` (0) a `EndGame` (7) | Verificar la tabla de Build Settings antes de compilar |
| **3** | Aviso `transparent_raycast` en botones Play y Quit | El componente `Image` tenía alfa 0 con `Raycast Target` activo | Validar con `audit_ui` que el área de clic coincida con el botón | Ejecutar auditoría de UI tras editar un Canvas |
| **4** | Se tomaban las 8 fotos en un segundo al pulsar `E` | Faltaba tiempo de espera entre capturas en `PhotoCamera.cs` | Agregar enfriamiento de 3 segundos con corrutina | Bloquear temporalmente entradas repetitivas |

## [0.1.0] - 2026-10-03
### Inicial
- Estructura inicial del proyecto en Unity 2022.3.62f3 LTS y levantamiento de scripts base.
