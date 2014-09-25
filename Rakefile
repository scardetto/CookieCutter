require 'physique'
require 'build_number'

BuildNumber.set_env

Physique::Solution.new do |s|
  s.file = 'src/CookieCutter.sln'

  s.publish_nugets do |p|
    p.feed_url = 'https://www.nuget.org'
    p.symbols_feed_url = 'http://nuget.gw.symbolsource.org/Public/NuGet'
    p.api_key = ENV['NUGET_API_KEY']

    p.with_metadata do |m|
      m.description = 'Quickly define and output fixed length files'
      m.authors = 'Robert Scaduto'
    end
  end
end
