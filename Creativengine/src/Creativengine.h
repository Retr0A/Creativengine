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
#include <iostream>