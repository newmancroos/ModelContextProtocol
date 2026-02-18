# ModelContextProtocol

<p>
The [Model Context Protocol (MCP) is an open-source standard created by Anthropic that acts as a universal, secure connector between AI models (like Claude) and external tools, data sources, or local files. It acts as a standardized translation layer, allowing LLMs to easily access data from Git, Slack, databases, and other applications without custom integrations for each, essentially acting as a "USB-C" for AI
</p>


<img width="598" height="362" alt="image" src="https://github.com/user-attachments/assets/861a427c-d2ad-4213-ae29-844be166e7a0" />


<img width="434" height="340" alt="image" src="https://github.com/user-attachments/assets/5b31e745-78ae-4c7e-baf7-0c8a44a779cf" />


<img width="531" height="369" alt="image" src="https://github.com/user-attachments/assets/ea31acc1-9f8c-4069-8d3a-6891dfa60bbc" />

<p>
LLM can access data from Git, databases, API and other applications but when we use multiple LLM like Gemini, GPT and Deep seek we need to  develop custom integration for each data source and each LLM, here we end up in MxN problem.
Here is where  MCP comes into place. It is a standardized translation layer allowing LLMs to easily access from multiple data sources.
</p>


MCP consist of three different important concept
1. MCP Host
2. MCP Client
3. MCP Server

<img width="375" height="339" alt="image" src="https://github.com/user-attachments/assets/ad8c564f-6630-47dc-8438-2e39cc635f1c" />


