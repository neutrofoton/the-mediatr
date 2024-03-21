# Summary

- <code>IPipelineBehavior&lt;TRequest, TResponse&gt;</code> is only applicable only compatible with <code>IRequestHandler&lt;TRequest,TResponse&gt;</code>. 

- <code>IPipelineBehavior&lt;TRequest, TResponse&gt;</code> can't be used with <code> INotificationHandler&lt;TRequest&gt; </code>

# Reference
https://github.com/jbogard/MediatR
https://github.com/jbogard/MediatR/wiki/Behaviors