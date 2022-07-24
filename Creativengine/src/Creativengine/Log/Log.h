#pragma once

#include "Creativengine.h"

namespace Creativengine {

	class CREATIVENGINE_API Log
	{
	public:

		static void Init();

		inline static std::shared_ptr<spdlog::logger>& GetCoreLogger() { return s_CoreLogger; }
		inline static std::shared_ptr<spdlog::logger>& GetClientLogger() { return s_ClientLogger; }
	private:

		static std::shared_ptr<spdlog::logger> s_CoreLogger;
		static std::shared_ptr<spdlog::logger> s_ClientLogger;
	};

}

// Core log macros
#define CE_CORE_TRACE(...)   ::Creativengine::Log::GetCoreLogger()->trace(__VA_ARGS__)
#define CE_CORE_INFO(...)    ::Creativengine::Log::GetCoreLogger()->info(__VA_ARGS__)
#define CE_CORE_WARN(...)    ::Creativengine::Log::GetCoreLogger()->warn(__VA_ARGS__)
#define CE_CORE_ERROR(...)   ::Creativengine::Log::GetCoreLogger()->error(__VA_ARGS__)
#define CE_CORE_FATAL(...)   ::Creativengine::Log::GetCoreLogger()->critical(__VA_ARGS__)
#define CE_CORE_DEBUG(...)   ::Creativengine::Log::GetCoreLogger()->debug(__VA_ARGS__)

// Client log macros
#define CE_TRACE(...)        ::Creativengine::Log::GetClientLogger()->trace(__VA_ARGS__)
#define CE_INFO(...)         ::Creativengine::Log::GetClientLogger()->info(__VA_ARGS__)
#define CE_WARN(...)         ::Creativengine::Log::GetClientLogger()->warn(__VA_ARGS__)
#define CE_ERROR(...)        ::Creativengine::Log::GetClientLogger()->error(__VA_ARGS__)
#define CE_FATAL(...)        ::Creativengine::Log::GetClientLogger()->critical(__VA_ARGS__)
#define CE_DEBUG(...)        ::Creativengine::Log::GetClientLogger()->debug(__VA_ARGS__)