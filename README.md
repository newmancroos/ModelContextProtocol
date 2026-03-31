# ModelContextProtocol

**What is Model Context Protocol (MCP)?**
<p>
The [Model Context Protocol (MCP) is an open-source standard created by Anthropic that acts as a universal, secure connector between AI models (like Claude) and external tools, data sources, or local files. It acts as a standardized translation layer, allowing LLMs to easily access data from Git, Slack, databases, and other applications without custom integrations for each, essentially acting as a "USB-C" for AI
</p>

<p>
  Its use to securely Connects + Interact with external data, tools and systems.  It is an open-source standard created by Anthropic. **MCP is a protocol that helps us to connect Host and the servers.**. 

1. Host - It is a client application interact with. ex, Claude, Visual Studio, VS Code or any AI tool.
2. Client - Each MCP Client is created by the host to connect to a specific MCP server. They have one-to-one relationship that is One client talk to one server.
3. Server - This is the program or service that gives the context or data that AI application need. Gmail, Folders ( the place where we write functions to connect to other tools), Or our own Api service

</p>
Learning Video Link : https://www.youtube.com/watch?v=4_aSQCcRtuA 
Simple Article : https://medium.com/aimonks/mcp-architecture-all-you-need-2cafe6c7d803

# MCP Architecture

<img width="593" height="434" alt="image" src="https://github.com/user-attachments/assets/7fe75f5b-dbdd-456c-8097-3f64ee123e77" />

<img width="569" height="700" alt="image" src="https://github.com/user-attachments/assets/ec9f5127-26e3-449e-95d1-06e4971e9b9d" />


<img width="598" height="362" alt="image" src="https://github.com/user-attachments/assets/861a427c-d2ad-4213-ae29-844be166e7a0" />


<img width="434" height="340" alt="image" src="https://github.com/user-attachments/assets/5b31e745-78ae-4c7e-baf7-0c8a44a779cf" />


<img width="531" height="369" alt="image" src="https://github.com/user-attachments/assets/ea31acc1-9f8c-4069-8d3a-6891dfa60bbc" />

<p>
LLM can access data from Git, databases, API and other applications but when we use multiple LLM like Gemini, GPT and Deep seek we need to  develop custom integration for each data source and each LLM, here we end up in MxN problem.
Here is where  MCP comes into place. It is a standardized translation layer allowing LLMs to easily access from multiple data sources.
</p>


MCP consist of three different important concept
1. MCP Host  (Our Application or Code)
2. MCP Client ( Connector lives within the host and talk to indivitual MCP server) 
3. MCP Server (Tool or data source using code C#)

<img width="375" height="339" alt="image" src="https://github.com/user-attachments/assets/ad8c564f-6630-47dc-8438-2e39cc635f1c" />

<img width="419" height="335" alt="image" src="https://github.com/user-attachments/assets/7a6f51eb-cee7-4f2f-8584-3ab4ac55e4b9" />


## Creating Host in Visual Studio Code

1. press Ctrl + Shift+p and select "MCP: Add Server"
2. Give our server api url
3. give a name
4. run the host and ask questions (ex. what is the weather in New york)

It will interpret  the question into a api end-point and call the web api.

We can also call MCP server (our MCP Api) from a semantic Kernal Agent line ChatGpt, Gemini etc.

## Build First AI Agent using Semantic Kernel in C#
(https://www.youtube.com/watch?v=4pI-LxK-NwE)
<br/>
https://www.youtube.com/watch?v=ZIBSD8ECuiw
<br/>
https://www.youtube.com/watch?v=v-HyooPh30w       --> Model Context Protocol Full video
<br/>
https://www.youtube.com/watch?v=IWZ5siSW8mA      --> Sematic Kernel AI Agent in WebApi calling MCP server

<img width="707" height="497" alt="image" src="https://github.com/user-attachments/assets/eb2fd1f8-e481-4617-aafc-43c5583c7943" />


<p>
  Semantic Kernel (SDK) is an open-source Software Development Kit (SDK) by Microsoft that enables developers to integrate Large Language Models (LLMs) like OpenAI and Azure OpenAI with conventional programming languages such as C#, Python, and Java. It acts as middleware to build AI agents, automate workflows, and connect AI models to external data sources. <br/>
  Sematic Kernel SDK allows to develop our custom AI agent. ex. Copilot is a Ai agent. We can create plugins that interface with LLM and perform all sort of tasks.
</p>
<p>
  
### What is Agent?


<img width="649" height="368" alt="image" src="https://github.com/user-attachments/assets/df48b617-f276-4ebb-a4f1-e28c4f9a52e1" />

  Here, LLM is the model, Instrcution are comments that instract with the LLM and Tools are custome code or Api end-point to our api.
</p>


<p>
  
  
** How to Access and Use**

-   **Access:**  Log in at oai.azure.com.
-   **Requirements:**  Requires an active Azure subscription and a deployed Azure OpenAI service resource.
-   **Management:**  It allows for managing deployment, API keys, and model versions.

-   We need modelId, end-point and Api-key to access open Ai model.
-    https://www.youtube.com/watch?v=LLO0lOufbwc
</p>

<p>
What is Azure Foundry?

https://www.youtube.com/watch?v=vgB1myP5lGk
  
</p>
<p>
  How to acces model play-ground and setup our model:<br/>
  https://www.youtube.com/watch?v=MB5YeEcfN_c
  <br/>
  Once we configure the model we can deploy it as webapp.
  
</p>
<img width="1356" height="667" alt="image" src="https://github.com/user-attachments/assets/105ff0de-87b6-43e3-924b-a0dffbd99977" />

<p>
## How to get Open Ai details from Azure AI foundry?

Steps to retrieve the required information

1.  **Get the API Key and Endpoint URL**:
    -   Navigate to the  Azure AI Foundry portal.
    -   Select your specific  **project**  from the project list.
    -   In the left navigation pane, select  **Settings**, then click on  **Keys and endpoints**  or  **Manage keys**.
    -   Copy the displayed  **API key**  (Key 1 or Key 2) and the  **Endpoint URL**. This URL will be the base URL for your API calls.
2.  **Get the Model Name**:
    -   Within your project in the  Azure AI Foundry portal, navigate to the  **Model Catalog**  or the specific model deployment section.
    -   Note the exact  **model name**  or  **deployment name**  you used when deploying the model in the studio. This name is a crucial parameter for your application code.
</p>

<b>Key Capabilities of Semantic Kernel: </b><br/>
<p>
<b>AI Orchestration:</b> Simplifies building AI agents that can chain together multiple tasks, such as generating text, answering questions, and performing actions, often with minimal code. <br/>
<b>Plugins & Connectors:</b> Allows integration with existing data sources, APIs, and tools, bridging the gap between LLMs and native code. <br/>
<b>Model Agnostic:</b> Supports multiple AI services, including OpenAI, Azure OpenAI, and others. <br/>
<b>Memory & Context:</b> Enables LLMs to access and utilize external data (Vector Search, RAG) for better, more grounded responses. <br/>
<b>Planners:</b> Automatically generates an execution plan to fulfill user requests using available tools.
</p>

<b>Core Components</b>
<p>
<b>Kernel:</b> The central object that manages configuration, plugins, and connectors. <br/>
<b>Plugins:</b> Functions that extend the capabilities of the LLM, such as calling APIs or accessing databases.<br/>
<b>Memory:</b> Stores and retrieves relevant information to provide context to the AI.<br/>
</p>
## Calling MCP server from  Semantic Kernel agent in C#
(https://www.youtube.com/watch?v=mOPEmxW82eg) 

- Using Sematic Kernal application as Model Context Protocol Host and in the Host application, create Model Context Protocol Client to communicate with our Model Context Server.

## What is LLM (Large Language Model)?
<p>
  A Large Language Model (LLM) is a type of AI designed to understand, process, and generate human-like text by analyzing massive datasets using deep learning, specifically transformer architectures. Key examples include ChatGPT, Gemini, and Claude,Llam which are used for summarizing, translating, and content generation.
</p>

<p>
Note: Ollama is a powerful, open-source tool designed to easily run LLM including Llma3, Mistral. It runs on your locall computer.
  
</p>
## What is SLM (Small Language Model)?
<p>
  Small Language Models (SLMs) are AI models with fewer parameters than LLMs, designed to be efficient, cost-effective, and capable of running on edge devices (smartphones, laptops). They are ideal for specific, specialized tasks rather than general-purpose reasoning, providing fast, localized, and private AI capabilities. Ex. Microsoft Phi-3.5/Phi-2, Google Gemma 2/3, Meta Llama.

  * On-device AI: Running chatbots, virtual assistants, or language translators on smartphones without needing a cloud connection.
  * Specialized Content Generation: Generating targeted marketing copy, summarizing documents, or writing code.
</p>

### What is RAG (Retrieval Augmented Generation)?
It retrieves relevant information from trusted data.  Example, retrieve information from a document. 
It acts as an external search machism like Bing, browsing uploaded documentys or querying a database to find accurate, up-to-date information outside the LLM. **It then inserts this context into the prompt**, helping the LLM generate a more precise answer.

## What is AI Agent?
AI Agent are AI systems that can:

- Think
- Decide
- Act
- Use Tools
- Complete task




