#include "EntryPoint.h"

int width = 1080;
int height = 600;
const char* title = "Creativengine";

CREATIVENGINE_API void Run()
{
	GLFWwindow* window;

	if (!glfwInit())
	{
		CE_CORE_FATAL("Failed Initializing GLFW!");
		return;
	}
	
	Creativengine::Log::Init();

	CE_CORE_INFO("Log Initialized!");
	CE_CORE_WARN("Engine Initialized!");

	CE_TRACE("Log Message");

	CE_CORE_INFO("GLFW Window Created With: Width: {0}, Height: {1}, Title: {2}", width, height, title);

	window = glfwCreateWindow(width, height, title, NULL, NULL);
	if (!window)
	{
		CE_CORE_FATAL("Failed Creating Window!");
		glfwTerminate();
		return;
	}

	if (glewInit() != GLEW_OK) {
	}

	glfwMakeContextCurrent(window);

	while (!glfwWindowShouldClose(window))
	{
		glClear(GL_COLOR_BUFFER_BIT);

		glBegin(GL_TRIANGLES);
		glVertex2f(-0.5f, -0.5f);
		glVertex2f(0.0f, 0.5f);
		glVertex2f(0.5f, -0.5f);
		glEnd();

		glClearColor(0.0f, 0.3f, 0.4f, 1.0f);

		glfwSwapBuffers(window);

		glfwPollEvents();

		glfwSetFramebufferSizeCallback(window, [](GLFWwindow* window, int width, int height) {

			glViewport(0, 0, width, height);

		});
	}

	glfwTerminate();
	return;
}