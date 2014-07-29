require 'physique'
require 'build_number'

BuildNumber.set_env

Physique::Solution.new do |s|
  s.file = 'src/CookieCutter.sln'

  s.publish_nugets do |p|
    p.feed_url = 'https://www.myget.org/F/thirdwave/api/v2/package'
    p.symbols_feed_url = 'https://nuget.symbolsource.org/MyGet/thirdwave'
    p.api_key = ENV['NUGET_API_KEY']

    p.with_metadata do |m|
      m.description = 'Quickly define and output fixed length files'
      m.authors = 'Robert Scaduto'
    end
  end
end
