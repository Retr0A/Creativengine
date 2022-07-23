#pragma once

#ifdef CE_WINDOWS
	#ifdef CE_BUILD_DLL
		#define CREATIVENGINE_API __declspec(dllexport)
	#else
		#define CREATIVENGINE_API __declspec(dllimport)
	#endif
#else
	#error Creativengine Supports Only Windows!
#endif

#include "Creativengine/EntryPoint.h"

// Includes
#include <GL/glew.h>
#include <GLFW/glfw3.h>
#include <spdlog/spdlog.h>
#include <spdlog/sinks/stdout_color_sinks.h>

#include "Creativengine/Log/Log.h"