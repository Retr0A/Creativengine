#pragma once

#include <Creativengine.h>

#define ASSERT(x) if (!(x)) __debugbreak();
#define GLCall(x) GLClearError();\
	x;\
	ASSERT(GLLogCall())

CREATIVENGINE_API void Run();